namespace GoldenMenu.Models.Middleware
{
    // Session Extension Builder

    public static class SessionExtensions
    {
        public static void SetUserSession(this ISession session, string username, int userId)
        {
            session.SetInt32("UserID", userId);
        }

        public static int? GetUserSession(this ISession session)
        {
            return session.GetInt32("UserID");
        }

        public static void ClearUserSession(this ISession session)
        {
            session.Remove("UserID");
        }
    }
}
