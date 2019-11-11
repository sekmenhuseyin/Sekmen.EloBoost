using Abp.Configuration;
using Abp.Zero.Configuration;
using EloBoost.Authorization.Accounts.Dto;
using EloBoost.Authorization.Users;
using EloBoost.Users.Dto;
using System.Threading.Tasks;

namespace EloBoost.Authorization.Accounts
{
    public class AccountAppService : EloBoostAppServiceBase, IAccountAppService
    {
        private readonly UserRegistrationManager _userRegistrationManager;
        private readonly UserManager _userManager;

        public AccountAppService(UserRegistrationManager userRegistrationManager, UserManager userManager)
        {
            _userRegistrationManager = userRegistrationManager;
            _userManager = userManager;
        }

        public async Task<RegisterOutput> Register(RegisterInput input)
        {
            var user = await _userRegistrationManager.RegisterAsync(
                input.Name,
                input.Surname,
                input.EmailAddress,
                input.UserName,
                input.Password,
                true // Assumed email address is always confirmed. Change this if you want to implement email confirmation.
            );

            var isEmailConfirmationRequiredForLogin = await SettingManager.GetSettingValueAsync<bool>(AbpZeroSettingNames.UserManagement.IsEmailConfirmationRequiredForLogin);

            return new RegisterOutput
            {
                CanLogin = user.IsActive && (user.IsEmailConfirmed || !isEmailConfirmationRequiredForLogin)
            };
        }

        public async Task<UserDto> MyProfile(long input)
        {
            var user = await _userManager.GetUserByIdAsync(input);
            return new UserDto
            {
                CreationTime = user.CreationTime,
                Credit = user.Credit,
                EmailAddress = user.EmailAddress,
                FullName = user.FullName,
                Guid = user.Guid,
                IsActive = user.IsActive,
                LastLoginTime = user.LastLoginTime,
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
                Id = user.Id,
                UserType = user.UserType
            };
        }
    }
}
