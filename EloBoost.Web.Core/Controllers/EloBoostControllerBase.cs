using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace EloBoost.Controllers
{
    public abstract class EloBoostControllerBase: AbpController
    {
        protected EloBoostControllerBase()
        {
            LocalizationSourceName = EloBoostConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
