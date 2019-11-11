using Abp.Application.Services;
using Abp.Domain.Repositories;
using EloBoost.Boosters.Dto;

namespace EloBoost.Boosters
{
    public class PricesAppService : AsyncCrudAppService<Prices, DtoPrices>
    {
        public PricesAppService(IRepository<Prices> repository) : base(repository)
        {
        }
    }
}
