using Abp.Application.Services.Dto;
using EloBoost.Boosters;
using EloBoost.Controllers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloBoost.Web.Controllers
{
    public class ApiController : EloBoostControllerBase
    {
        private readonly PricesAppService _pricesAppService;

        public ApiController(PricesAppService pricesAppService)
        {
            _pricesAppService = pricesAppService;
        }

        /// <summary>
        /// Gets All Prices Via js File
        /// </summary>
        /// <returns>JS File</returns>
        public async Task<JavaScriptResult> GetPriceJs()
        {
            //get all price list
            var model = (await _pricesAppService.GetAll(new PagedAndSortedResultRequestDto { MaxResultCount = int.MaxValue, SkipCount = 0 })).Items
                .OrderBy(m => m.PointsPerMatch)
                .ThenBy(m => m.Order)
                .ToList();
            //create js
            var sb = new StringBuilder();
            sb.Append("var priceList = [");
            foreach (var item in model)
            {
                sb.Append($"[\"{(byte)item.PointsPerMatch}\",\"{(byte)item.LeagueType}\",\"{(byte)item.DivisionType}\",{item.Price}],");
            }
            sb.Append("];");
            //return js
            return new JavaScriptResult(sb.ToString());
        }
    }
}