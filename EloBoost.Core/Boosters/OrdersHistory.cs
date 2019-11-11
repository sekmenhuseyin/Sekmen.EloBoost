using Abp.Domain.Entities.Auditing;
using EloBoost.Authorization.Users;
using EloBoost.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EloBoost.Boosters
{
    [Table("OrdersHistory")]
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class OrdersHistory : FullAuditedEntity<long>
    {
        [Required]
        public virtual Orders Orders { get; set; }
        public virtual long OrdersId { get; set; }

        [Required]
        public virtual OrderStatus OrderStatus { get; set; }
    }
}
