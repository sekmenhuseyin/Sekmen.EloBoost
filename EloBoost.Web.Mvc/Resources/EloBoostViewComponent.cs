using Abp.AspNetCore.Mvc.ViewComponents;

namespace EloBoost.Web.Views
{
    public abstract class EloBoostViewComponent : AbpViewComponent
    {
        protected EloBoostViewComponent()
        {
            LocalizationSourceName = EloBoostConsts.LocalizationSourceName;
        }
    }
}
