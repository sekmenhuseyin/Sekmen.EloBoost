using Abp.Authorization.Users;
using Abp.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using EloBoost.Shared.Enums;

namespace EloBoost.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public virtual Guid Guid { get; set; }

        public virtual UserType UserType { get; set; }

        public virtual decimal Credit { get; set; }

        //public virtual string Avatar { get; set; }

        [StringLength(EloBoostConsts.LengthTwoFifty)]
        public override string Password { get; set; }

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(string userName, string emailAddress, UserType userType)
        {
            var user = new User
            {
                TenantId = 1,
                UserName = userName,
                Name = userName,
                Surname = userName,
                EmailAddress = emailAddress,
                Guid = Guid.NewGuid(),
                UserType = userType,
                IsEmailConfirmed = true,
                IsLockoutEnabled = false,
                IsActive = true
            };

            user.SetNormalizedNames();

            return user;
        }
    }
}
