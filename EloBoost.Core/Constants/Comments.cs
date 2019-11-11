using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations.Schema;

namespace EloBoost.Constants
{
    [Table("Comments")]
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class Comments : FullAuditedEntity<long>
    {
        public virtual string Name { get; set; }

        public virtual string Comment { get; set; }

        public virtual byte Points { get; set; }
    }
}
