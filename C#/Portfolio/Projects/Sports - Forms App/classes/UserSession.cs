namespace _3Sports.classes
{
    public class UserSession
    {
        public static string CurrentUsername { get; set; } // Store the username of the logged-in user
        public static string CurrentEmail { get; set; } // Store the email of the logged-in user
        public static string LastLoggedIn { get; set; } // Store the last logged-in date of the user
    }
}
