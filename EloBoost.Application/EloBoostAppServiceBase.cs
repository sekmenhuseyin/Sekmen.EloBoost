using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using EloBoost.Authorization.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace EloBoost
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class EloBoostAppServiceBase : ApplicationService
    {
        public UserManager UserManager { get; set; }

        protected EloBoostAppServiceBase()
        {
            LocalizationSourceName = EloBoostConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
