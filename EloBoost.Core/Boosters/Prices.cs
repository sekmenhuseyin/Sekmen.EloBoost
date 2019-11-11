using Abp.Domain.Entities;
using EloBoost.Shared.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EloBoost.Boosters
{
    [Table("Prices")]
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class Prices : Entity
    {
        [Required]
        public virtual LeagueTypes LeagueType { get; set; }

        [Required]
        public virtual DivisionTypes DivisionType { get; set; }

        [Required]
        public virtual LeaguePoints PointsPerMatch { get; set; }

        [Required]
        public virtual decimal Price { get; set; }

        [Required]
        public virtual short Order { get; set; }
    }
}
