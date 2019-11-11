using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EloBoost.Shared.Enums;
using System;

namespace EloBoost.Boosters.Dto
{
    [AutoMapFrom(typeof(Payments))]
    public class DtoPayments : FullAuditedEntityDto<long>
    {
        public long OrderId { get; set; }

        public Guid Guid { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public decimal Amount { get; set; }
    }
}
