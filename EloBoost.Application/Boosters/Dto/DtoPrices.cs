using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using EloBoost.Shared.Enums;

namespace EloBoost.Boosters.Dto
{
    [AutoMapFrom(typeof(Prices))]
    public class DtoPrices : EntityDto
    {
        public LeagueTypes LeagueType { get; set; }

        public DivisionTypes DivisionType { get; set; }

        public LeaguePoints PointsPerMatch { get; set; }

        public decimal Price { get; set; }

        public short Order { get; set; }
    }
}
