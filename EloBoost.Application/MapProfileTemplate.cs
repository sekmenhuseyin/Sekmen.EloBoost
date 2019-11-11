using AutoMapper;
using EloBoost.Boosters;
using EloBoost.Boosters.Dto;

namespace EloBoost
{
    /// <summary>
    /// Profile class automatically maps classes, you don't have to initiate it
    /// ReSharper disable once UnusedMember.Global
    /// </summary>
    public class MapProfileTemplate : Profile
    {
        public MapProfileTemplate()
        {
            CreateMap<DtoPayments, Payments>();
            CreateMap<DtoOrders, Orders>();
            CreateMap<DtoOrdersHistory, OrdersHistory>();
            CreateMap<DtoPrices, Prices>();
        }
    }
}
