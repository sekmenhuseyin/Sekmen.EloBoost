using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Runtime.Session;
using EloBoost.Controllers;
using EloBoost.Users;
using Microsoft.AspNetCore.Mvc;

namespace EloBoost.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ProfileController : EloBoostControllerBase
    {
        private readonly UserAppService _userAppService;

        public ProfileController(UserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _userAppService.Get(new EntityDto<long> {Id = AbpSession.GetUserId()});
            return View(model);
        }
    }
}