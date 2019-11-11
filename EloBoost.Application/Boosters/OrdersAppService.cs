using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using EloBoost.Boosters.Dto;
using EloBoost.Shared.Extensions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EloBoost.Boosters
{
    public class OrdersAppService : AsyncCrudAppService<Orders, DtoOrders, long>, IGetAllAppService<DtoOrders>
    {
        public OrdersAppService(IRepository<Orders, long> repository) : base(repository)
        {
        }

        public virtual async Task<PagedResultDto<DtoOrders>> GetAllByUser(InputSearch input)
        {
            CheckGetAllPermission();

            var query = Repository.GetAll()
                .WhereIf(input.ClientId > 0, m => m.CreatorUserId == input.ClientId)
                //.WhereIf(input.UserId > 0, m => m.UserId == input.UserId)
                .WhereIf(!input.Guid.IsNullEmpty(), m => m.Guid == new Guid(input.Guid));

            var totalCount = await AsyncQueryableExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncQueryableExecuter.ToListAsync(query);

            return new PagedResultDto<DtoOrders>(
                totalCount,
                entities.Select(MapToEntityDto).ToList()
            );
        }
    }
}
