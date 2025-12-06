using GoldenMenu.Data.DBContext;
using GoldenMenu.Models.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Text.Json;

namespace Golden_Menu.Controllers
{
    public class MealPlanController : Controller
    {
        private readonly GMDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        // Configurations
        public MealPlanController(IConfiguration configuration, IHttpClientFactory httpClientFactory, GMDbContext context)
        {
            _configuration = configuration;
            _httpClient = httpClientFactory.CreateClient();
            _context = context;
        }

        [Authorize] // Only logged / Authenticated Users
        public IActionResult MealPlanForm()
        {
            return View("~/Views/MealPlan/MealPlan.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> SavePreferencesAndGenerate(string dietaryRestrictions, string favoriteFoods, string avoidFoods, int mealsPerDay)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            int userId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserID")?.Value ?? "0");
            ;

            // Step-1. It checks if the user already has preferences saved
            var existingPreferences = _context.Preferences.FirstOrDefault(p => p.UserID == userId);

            if (existingPreferences != null)
            {
                // Step-2. Then update existing preferences
                existingPreferences.Likes = favoriteFoods;
                existingPreferences.Dislikes = avoidFoods;

                // In Future - I might need to adjust my mapping
                existingPreferences.Allergies = dietaryRestrictions;
            }
            else
            {
                // Step-3. Then create new preferences
                var newPreference = new Preference
                {
                    UserID = userId,
                    Likes = favoriteFoods,
                    Dislikes = avoidFoods,
                    Allergies = dietaryRestrictions
                };
                _context.Preferences.Add(newPreference);
            }

            _context.SaveChanges();

            // Step-4. Lastly generate the meal plan
            return await Generate(dietaryRestrictions, favoriteFoods, avoidFoods, mealsPerDay);
        }

        [HttpPost]
        public async Task<IActionResult> Generate(string dietaryRestrictions, string favoriteFoods, string avoidFoods, int mealsPerDay)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "User");
            }

            string apiKey = _configuration["OpenAISettings:ApiKey"];
            if (string.IsNullOrEmpty(apiKey))
            {
                ViewBag.ErrorMessage = "ChatGPT API key not found in configuration.";
                return View("MealPlanResult");
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            var apiUrl = "https://api.openai.com/v1/chat/completions"; // Using the chat completions API

            // ------------------------- TEST PROMPT ---------------------- //

            //var prompt = $"Generate a 7 day detailed meal plan for someone with the following preferences:\n\nDietary Restrictions: {dietaryRestrictions}\nFavorite Foods: {favoriteFoods}\nFoods to Avoid: {avoidFoods}\nNumber of Meals per Day: {mealsPerDay}. Please provide specific meal suggestions for each meal.";

            // -------------------------      END     ---------------------- //

            // ------------------------- WORKING PROMPT -------------------- //
            var prompt = $@"
            I need a 7-day meal plan for healthy eating, with foods that are reasonably priced and simple to make. I love to eat {favoriteFoods}, but I hate to eat {avoidFoods}. I am also allergic to {dietaryRestrictions}. Please create a 7-day meal plan for me.

            Instructions:
            - Provide the meal plan in plain text only.
            - Do not use asterisks (**), underscores (_), or any other Markdown or formatting characters.
            - List each day clearly with meal names (e.g., Day 1: Breakfast - Oatmeal, Lunch - Grilled Chicken).
            ";

            var requestBody = new
            {
                //  Different model can be adjusted.
                model = "gpt-4",
                messages = new[]
                {
                    new { role = "system", content = "You are a professional dietitian creating weekly meal plans for elderly people. Make sure meals are simple, healthy, are reasonably priced and simple to make, and personalized." },
                    new { role = "user", content = prompt }
                },

                // The length of the response can also be adjsuted.
                max_tokens = 500,

                // For better creativity, the temperature can also be adjusted from range 0.0 - 1.0
                temperature = 0.7,
                //top_p = 1.0,

                // These will avoid repeating same meals everytime or even phrases
                frequency_penalty = 0.3,

                // Some diversity in meals
                presence_penalty = 0.2,
            };

            var jsonRequestBody = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(apiUrl, content);

                // Throws an exception for bad status codes
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                var jsonDocument = JsonDocument.Parse(responseJson);

                if (jsonDocument.RootElement.TryGetProperty("choices", out var choices) && choices.GetArrayLength() > 0)
                {
                    if (choices[0].TryGetProperty("message", out var message) && message.TryGetProperty("content", out var mealPlanContent))
                    {
                        ViewBag.MealPlan = mealPlanContent.GetString();

                        // For my purposes, I get the TempData to generate the PDF's and Service Improvements.
                        // And will use it for both Email and PDF Services.
                        TempData["MealPlan"] = ViewBag.MealPlan;
                        return View("MealPlanResult");
                    }
                }

                ViewBag.ErrorMessage = "Failed to extract meal plan from the ChatGPT response.";
            }
            catch (HttpRequestException ex)
            {
                ViewBag.ErrorMessage = $"Error communicating with ChatGPT: {ex.Message}";
            }
            catch (JsonException ex)
            {
                ViewBag.ErrorMessage = $"Error parsing ChatGPT response: {ex.Message}";
            }

            return View("MealPlanResult");
        }


        // Download Logic
        [HttpPost]
        public IActionResult DownloadMealPlan()
        {
            var mealPlanText = TempData["MealPlan"] as string;

            if (string.IsNullOrEmpty(mealPlanText))
                return RedirectToAction("Result");

            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header().Text("Your Personalized Meal Plan").FontSize(20).Bold().FontColor(Colors.Blue.Medium);
                    page.Content().PaddingVertical(20).Text(mealPlanText).FontSize(12);
                });
            });

            var pdfStream = new MemoryStream();
            pdf.GeneratePdf(pdfStream);
            pdfStream.Position = 0;

            return File(pdfStream, "application/pdf", "MealPlan.pdf");
        }


        // Email Logic -- Not yet Functionally due to missing setups.
        // If approved then I can work towards it.
        [HttpPost]
        public IActionResult EmailMealPlan()
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == "Email")?.Value;

            if (string.IsNullOrEmpty(userEmail))
            {
                TempData["Error"] = "User email not found.";
                return RedirectToAction("Result");
            }

            var mealPlanText = TempData["MealPlan"] as string;

            if (string.IsNullOrEmpty(mealPlanText))
            {
                TempData["Error"] = "Meal plan data is missing.";
                return RedirectToAction("Result");
            }

            // Generate a PDF using QuestPDF
            var pdfStream = new MemoryStream();
            var pdf = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header().Text("Your Personalized Meal Plan").FontSize(20).Bold();
                    page.Content().PaddingVertical(20).Text(mealPlanText).FontSize(12);
                });
            });
            pdf.GeneratePdf(pdfStream);
            pdfStream.Position = 0;

            using (var smtpClient = new SmtpClient(_configuration["EmailSettings:SmtpServer"])
            {
                Port = int.Parse(_configuration["EmailSettings:Port"]),
                Credentials = new NetworkCredential(
                    _configuration["EmailSettings:Username"],
                    _configuration["EmailSettings:Password"]),
                EnableSsl = true
            })
            {
                var mail = new MailMessage
                {
                    From = new MailAddress(_configuration["EmailSettings:SenderEmail"]),
                    Subject = "Your Personalized Meal Plan",
                    Body = "Hi! Please find your meal plan attached as a PDF.",
                    IsBodyHtml = false
                };

                mail.To.Add(userEmail);
                mail.Attachments.Add(new Attachment(pdfStream, "MealPlan.pdf", "application/pdf"));

                try
                {
                    smtpClient.Send(mail);
                    TempData["Message"] = "Meal plan emailed successfully!";
                }
                catch (Exception ex)
                {
                    TempData["Error"] = $"Email sending failed: {ex.Message}";
                }
            }

            return RedirectToAction("Result");
        }

    }
}