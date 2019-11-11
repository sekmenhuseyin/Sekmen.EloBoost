using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EloBoost.Shared.Enums;
using System;

namespace EloBoost.Boosters.Dto
{
    [AutoMapFrom(typeof(Orders))]
    public class DtoOrders : FullAuditedEntityDto<long>
    {
        public long UserId { get; set; }

        public Guid Guid { get; set; }

        public BoostType BoostType { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public ServerNames ServerName { get; set; }

        public QueueTypes QueueType { get; set; }

        public LeagueTypes CurrentLeague { get; set; }

        public DivisionTypes CurrentDivision { get; set; }

        public LeaguePoints CurrentPoints { get; set; }

        public LeagueTypes DesiredLeague { get; set; }

        public DivisionTypes DesiredDivision { get; set; }

        public ServiceType ServiceType { get; set; }

        public int DesiredGamesOrWinsOrPoints { get; set; }

        public decimal Amount { get; set; }
    }
}