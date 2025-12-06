using GoldenMenu.Data.DBContext;
using GoldenMenu.Models.Auth;

namespace GoldenMenu.Services
{
    public class UserService : IUserService
    {
        private readonly GMDbContext _context;

        public UserService(GMDbContext context)
        {
            _context = context;
        }

        public UserProfileViewModel GetProfile(string userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userId);
            return new UserProfileViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

        public void UpdateProfile(string userId, UserProfileViewModel model)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userId);
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            _context.SaveChanges();
        }

        public bool ChangePassword(string userId, ChangePasswordViewModel model)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == userId);
            if (user.Password != model.OldPassword) return false;

            user.Password = model.NewPassword;
            _context.SaveChanges();
            return true;
        }
    }

}
