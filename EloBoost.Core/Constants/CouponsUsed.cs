using Abp.Domain.Entities.Auditing;
using EloBoost.Authorization.Users;
using EloBoost.Boosters;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EloBoost.Constants
{
    [Table("CouponsUsed")]
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class CouponsUsed : FullAuditedEntity<long>
    {
        [Required]
        public virtual User User { get; set; }
        public virtual long UserId { get; set; }

        [Required]
        public virtual Coupons Coupon { get; set; }
        public virtual int CouponId { get; set; }

        [Required]
        public virtual Payments Payment { get; set; }
        public virtual long PaymentId { get; set; }
    }
}
