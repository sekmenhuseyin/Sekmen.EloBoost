using EloBoost.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EloBoost.Web.Controllers
{
    public class TermsOfUseController : EloBoostControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}