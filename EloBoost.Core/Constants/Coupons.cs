using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EloBoost.Constants
{
    [Table("Coupons")]
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class Coupons : FullAuditedEntity
    {
        [Required]
        public virtual Guid Guid { get; set; }

        [Required]
        public virtual decimal Percentage { get; set; }

        [Required]
        public virtual DateTime StartDateTime { get; set; }

        [Required]
        public virtual DateTime EndDateTime { get; set; }
    }
}
