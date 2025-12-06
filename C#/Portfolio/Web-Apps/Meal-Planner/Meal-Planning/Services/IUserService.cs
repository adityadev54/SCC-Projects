using GoldenMenu.Models.Auth;

namespace GoldenMenu.Services
{
    public interface IUserService
    {
        UserProfileViewModel GetProfile(string userId);
        void UpdateProfile(string userId, UserProfileViewModel model);
        bool ChangePassword(string userId, ChangePasswordViewModel model);
    }

}
