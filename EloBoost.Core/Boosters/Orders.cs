using Abp.Domain.Entities.Auditing;
using EloBoost.Authorization.Users;
using EloBoost.Shared.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EloBoost.Boosters
{
    [Table("Orders")]
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class Orders : FullAuditedEntity<long>
    {
        /// <summary>
        /// Booster / Coach ID
        /// </summary>
        [Required]
        public virtual User User { get; set; }
        public virtual long UserId { get; set; }

        [Required]
        public virtual Guid Guid { get; set; }

        [Required]
        public virtual BoostType BoostType { get; set; }

        [Required]
        public virtual OrderStatus OrderStatus { get; set; }

        [Required]
        public virtual ServerNames ServerName { get; set; }

        [Required]
        public virtual QueueTypes QueueType { get; set; }

        public virtual LeagueTypes CurrentLeague { get; set; }

        public virtual DivisionTypes CurrentDivision { get; set; }

        public virtual LeaguePoints CurrentPoints { get; set; }

        public virtual LeagueTypes DesiredLeague { get; set; }

        public virtual DivisionTypes DesiredDivision { get; set; }

        public virtual ServiceType ServiceType { get; set; }

        public virtual int DesiredGamesOrWinsOrPoints { get; set; }

        public virtual decimal Amount { get; set; }
    }
}
