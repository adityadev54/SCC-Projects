namespace GoldenMenu.Models.ViewModels
{
    // Models/ViewModels/ProfileViewModel.cs
    public class ProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool IsDarkTheme { get; set; }
        public bool AutoSaveEnabled { get; set; }
        public bool NotificationsEnabled { get; set; }
    }

}



