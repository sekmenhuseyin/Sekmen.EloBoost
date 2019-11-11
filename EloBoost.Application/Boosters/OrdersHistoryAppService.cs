using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using EloBoost.Boosters.Dto;
using System.Linq;
using System.Threading.Tasks;

namespace EloBoost.Boosters
{
    public class OrdersHistoryAppService : AsyncCrudAppService<OrdersHistory, DtoOrdersHistory, long>, IGetAllAppService<DtoOrdersHistory>
    {
        public OrdersHistoryAppService(IRepository<OrdersHistory, long> repository) : base(repository)
        {
        }

        public virtual async Task<PagedResultDto<DtoOrdersHistory>> GetAllByUser(InputSearch input)
        {
            CheckGetAllPermission();

            var query = Repository.GetAll()
                .WhereIf(input.ClientId > 0, m => m.CreatorUserId == input.ClientId);

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<DtoOrdersHistory>(
                totalCount,
                entities.Select(MapToEntityDto).ToList()
            );
        }
    }
}
