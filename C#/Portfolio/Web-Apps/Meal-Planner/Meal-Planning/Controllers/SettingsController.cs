using GoldenMenu.Models.Auth;
using GoldenMenu.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Golden_Menu.Controllers
{
    public class SettingsController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _env;

        public SettingsController(IUserService userService, IWebHostEnvironment env)
        {
            _userService = userService;
            _env = env;
        }

        public IActionResult Settings()
        {
            var userId = User.Identity.Name; // or however you get it
            var profile = _userService.GetProfile(userId);
            ViewBag.Version = "v.0.1";
            return View("~/Views/Settings/SettingsView.cshtml", profile);
        }

        [HttpPost]
        public IActionResult UpdateProfile(UserProfileViewModel model)
        {
            if (!ModelState.IsValid) return View("Settings", model);

            var userId = User.Identity.Name;
            _userService.UpdateProfile(userId, model);
            ViewBag.Message = "Profile updated.";
            return RedirectToAction("Settings");
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid) return PartialView("_ChangePasswordPartial", model);

            var userId = User.Identity.Name;
            var success = _userService.ChangePassword(userId, model);
            if (!success)
            {
                ModelState.AddModelError("", "Old password incorrect.");
                return PartialView("_ChangePasswordPartial", model);
            }

            ViewBag.PasswordMessage = "Password changed!";
            return PartialView("_ChangePasswordPartial", new ChangePasswordViewModel());
        }

        public IActionResult GetVersion()
        {
            var path = Path.Combine(_env.WebRootPath, "version.json");
            var versionJson = System.IO.File.ReadAllText(path);
            dynamic version = JsonConvert.DeserializeObject(versionJson);
            return PartialView("_VersionPartial", version.version.ToString());
        }
    }

}
