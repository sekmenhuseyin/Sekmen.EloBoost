using Abp.AspNetCore.Mvc.Authorization;
using Abp.Runtime.Session;
using EloBoost.Authorization.Accounts;
using EloBoost.Controllers;
using EloBoost.Users.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EloBoost.Web.Controllers
{
    [AbpMvcAuthorize]
    public class PurchaseController : EloBoostControllerBase
    {
        private readonly IAccountAppService _accountAppService;

        public PurchaseController(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }

        public async Task<IActionResult> Index()
        {
            UserDto user = await _accountAppService.MyProfile(AbpSession.GetUserId());
            return View(user);
        }
    }
}