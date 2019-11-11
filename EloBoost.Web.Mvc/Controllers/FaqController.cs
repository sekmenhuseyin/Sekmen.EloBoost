using EloBoost.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EloBoost.Web.Controllers
{
    public class FaqController : EloBoostControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}