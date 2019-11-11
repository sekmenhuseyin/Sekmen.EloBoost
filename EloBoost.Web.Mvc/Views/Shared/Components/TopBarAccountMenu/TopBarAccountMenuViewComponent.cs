using EloBoost.Sessions;
using EloBoost.Sessions.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EloBoost.Web.Views.Shared.Components.TopBarAccountMenu
{
    public class TopBarAccountMenuViewComponent : EloBoostViewComponent
    {
        private readonly UserLoginInfoDto _user;

        public TopBarAccountMenuViewComponent(ISessionAppService sessionAppService)
        {
            _user = sessionAppService.GetCurrentLoginInformations().Result.User;
        }

        public IViewComponentResult Invoke()
        {
            return View(_user);
        }
    }
}
