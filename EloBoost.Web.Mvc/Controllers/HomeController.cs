using EloBoost.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EloBoost.Web.Controllers
{
    public class HomeController : EloBoostControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
