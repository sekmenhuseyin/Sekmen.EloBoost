using EloBoost.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EloBoost.Web.Controllers
{
    public class RulesController : EloBoostControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}