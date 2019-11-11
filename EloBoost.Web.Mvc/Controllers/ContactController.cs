using EloBoost.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace EloBoost.Web.Controllers
{
    public class ContactController : EloBoostControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}