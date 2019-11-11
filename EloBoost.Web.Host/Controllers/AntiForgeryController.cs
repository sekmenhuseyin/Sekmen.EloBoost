using Microsoft.AspNetCore.Antiforgery;
using EloBoost.Controllers;

namespace EloBoost.Web.Host.Controllers
{
    public class AntiForgeryController : EloBoostControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
