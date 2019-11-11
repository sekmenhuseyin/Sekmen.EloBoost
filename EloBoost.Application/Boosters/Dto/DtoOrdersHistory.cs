using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EloBoost.Shared.Enums;

namespace EloBoost.Boosters.Dto
{
    [AutoMapFrom(typeof(OrdersHistory))]
    public class DtoOrdersHistory : FullAuditedEntityDto<long>
    {
        public virtual long OrdersId { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}