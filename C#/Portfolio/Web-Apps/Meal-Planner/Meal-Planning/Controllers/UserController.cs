using GoldenMenu.Data.DBContext;
using GoldenMenu.Models.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Golden_Menu.Controllers
{
    public class UserController : Controller
    {
        private readonly GMDbContext _context;

        public UserController(GMDbContext context)
        {
            _context = context;
        }

        // Register Logic
        public IActionResult Register()
        {
            return View("~/Views/Auth/Register.cshtml");
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = HashPassword(user.Password);
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(user);
        }

        // Login Logic
        public IActionResult Login()
        {
            return View("~/Views/Auth/Login.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, bool rememberMe)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user != null && user.Password == HashPassword(password))
            {
                // Set the session values
                HttpContext.Session.SetString("FirstName", user.FirstName.ToString());
                HttpContext.Session.SetString("UserEmail", user.Email);

                // And then Create claims for the authenticated user
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim("UserID", user.UserID.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    // Keeps the user logged in till Manual Logout
                    IsPersistent = rememberMe,

                    // Session timeout
                    ExpiresUtc = rememberMe ? DateTimeOffset.UtcNow.AddMinutes(30) : DateTimeOffset.UtcNow.AddMinutes(30)
                }
            ;

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties
                );

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Error", "Home");
            ViewBag.Error = "Invalid Credentials";
            return View();
        }


        // Logout Logic
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear(); // Clears up the session
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme); // And this ensures the async logout
            return RedirectToAction("Login");
        }



        // Password Hashing Logic
        private string HashPassword(string pin)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pin));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();

            }
        }
    }
}
