using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using EloBoost.Controllers;

namespace EloBoost.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : EloBoostControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
