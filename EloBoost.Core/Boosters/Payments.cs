using Abp.Domain.Entities.Auditing;
using EloBoost.Shared.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EloBoost.Boosters
{
    [Table("Payments")]
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class Payments : FullAuditedEntity<long>
    {
        [Required]
        public virtual Orders Order { get; set; }
        public virtual long OrderId { get; set; }

        [Required]
        public virtual Guid Guid { get; set; }

        [Required]
        public virtual PaymentStatus PaymentStatus { get; set; }

        [Required]
        public virtual PaymentMethod PaymentMethod { get; set; }

        [Required]
        public virtual decimal Amount { get; set; }
    }
}
