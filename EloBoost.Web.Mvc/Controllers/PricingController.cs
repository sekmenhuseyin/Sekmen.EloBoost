using Abp.AspNetCore.Mvc.Authorization;
using EloBoost.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EloBoost.Web.Controllers
{
    [AbpMvcAuthorize]
    public class PricingController : EloBoostControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}