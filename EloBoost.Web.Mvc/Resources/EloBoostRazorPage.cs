using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace EloBoost.Web.Views
{
    public abstract class EloBoostRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected EloBoostRazorPage()
        {
            LocalizationSourceName = EloBoostConsts.LocalizationSourceName;
        }
    }
}
