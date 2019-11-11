using Abp.AspNetCore.Mvc.Authorization;
using EloBoost.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EloBoost.Web.Controllers
{
    [AbpMvcAuthorize]
    public class DashBoardController : EloBoostControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}