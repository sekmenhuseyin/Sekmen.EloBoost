using EloBoost.Sessions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EloBoost.Web.Views.Shared.Components.SideBarUserArea
{
    public class SideBarUserAreaViewComponent : EloBoostViewComponent
    {
        private readonly ISessionAppService _sessionAppService;

        public SideBarUserAreaViewComponent(ISessionAppService sessionAppService)
        {
            _sessionAppService = sessionAppService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new SideBarUserAreaViewModel
            {
                LoginInformations = await _sessionAppService.GetCurrentLoginInformations()
            };

            return View(model);
        }
    }
}
