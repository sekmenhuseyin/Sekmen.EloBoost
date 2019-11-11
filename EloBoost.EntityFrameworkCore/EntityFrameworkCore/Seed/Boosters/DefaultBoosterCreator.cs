using EloBoost.Boosters;
using EloBoost.Shared.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EloBoost.EntityFrameworkCore.Seed.Boosters
{
    public class DefaultBoosterCreator
    {
        private readonly EloBoostDbContext _context;

        public DefaultBoosterCreator(EloBoostDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateDefaultPrices();
        }

        private void CreateDefaultPrices()
        {
            var price = _context.Prices.IgnoreQueryFilters().FirstOrDefault();
            if (price != null) return;

            //add LeaguePoints.Lp0 prices
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Bronze, DivisionType = DivisionTypes.Division5, PointsPerMatch = LeaguePoints.Lp0, Order = 1, Price = 40 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Bronze, DivisionType = DivisionTypes.Division4, PointsPerMatch = LeaguePoints.Lp0, Order = 2, Price = 40 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Bronze, DivisionType = DivisionTypes.Division3, PointsPerMatch = LeaguePoints.Lp0, Order = 3, Price = 40 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Bronze, DivisionType = DivisionTypes.Division2, PointsPerMatch = LeaguePoints.Lp0, Order = 4, Price = 40 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Bronze, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp0, Order = 5, Price = 40 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Silver, DivisionType = DivisionTypes.Division5, PointsPerMatch = LeaguePoints.Lp0, Order = 6, Price = 43 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Silver, DivisionType = DivisionTypes.Division4, PointsPerMatch = LeaguePoints.Lp0, Order = 7, Price = 48 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Silver, DivisionType = DivisionTypes.Division3, PointsPerMatch = LeaguePoints.Lp0, Order = 8, Price = 48 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Silver, DivisionType = DivisionTypes.Division2, PointsPerMatch = LeaguePoints.Lp0, Order = 9, Price = 48 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Silver, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp0, Order = 10, Price = 48 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Gold, DivisionType = DivisionTypes.Division5, PointsPerMatch = LeaguePoints.Lp0, Order = 11, Price = 52 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Gold, DivisionType = DivisionTypes.Division4, PointsPerMatch = LeaguePoints.Lp0, Order = 12, Price = 59 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Gold, DivisionType = DivisionTypes.Division3, PointsPerMatch = LeaguePoints.Lp0, Order = 13, Price = 59 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Gold, DivisionType = DivisionTypes.Division2, PointsPerMatch = LeaguePoints.Lp0, Order = 14, Price = 59 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Gold, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp0, Order = 15, Price = 59 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Platinum, DivisionType = DivisionTypes.Division5, PointsPerMatch = LeaguePoints.Lp0, Order = 16, Price = 64 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Platinum, DivisionType = DivisionTypes.Division4, PointsPerMatch = LeaguePoints.Lp0, Order = 17, Price = 70 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Platinum, DivisionType = DivisionTypes.Division3, PointsPerMatch = LeaguePoints.Lp0, Order = 18, Price = 70 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Platinum, DivisionType = DivisionTypes.Division2, PointsPerMatch = LeaguePoints.Lp0, Order = 19, Price = 70 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Platinum, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp0, Order = 20, Price = 70 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Diamond, DivisionType = DivisionTypes.Division5, PointsPerMatch = LeaguePoints.Lp0, Order = 21, Price = 90 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Diamond, DivisionType = DivisionTypes.Division4, PointsPerMatch = LeaguePoints.Lp0, Order = 22, Price = 112 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Diamond, DivisionType = DivisionTypes.Division3, PointsPerMatch = LeaguePoints.Lp0, Order = 23, Price = 125 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Diamond, DivisionType = DivisionTypes.Division2, PointsPerMatch = LeaguePoints.Lp0, Order = 24, Price = 140 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Diamond, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp0, Order = 25, Price = 156 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Master, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp0, Order = 26, Price = 280 });

            //add LeaguePoints.Lp1 prices
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Bronze, DivisionType = DivisionTypes.Division5, PointsPerMatch = LeaguePoints.Lp1, Order = 1, Price = 26 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Bronze, DivisionType = DivisionTypes.Division4, PointsPerMatch = LeaguePoints.Lp1, Order = 2, Price = 26 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Bronze, DivisionType = DivisionTypes.Division3, PointsPerMatch = LeaguePoints.Lp1, Order = 3, Price = 26 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Bronze, DivisionType = DivisionTypes.Division2, PointsPerMatch = LeaguePoints.Lp1, Order = 4, Price = 26 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Bronze, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp1, Order = 5, Price = 26 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Silver, DivisionType = DivisionTypes.Division5, PointsPerMatch = LeaguePoints.Lp1, Order = 6, Price = 29 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Silver, DivisionType = DivisionTypes.Division4, PointsPerMatch = LeaguePoints.Lp1, Order = 7, Price = 31 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Silver, DivisionType = DivisionTypes.Division3, PointsPerMatch = LeaguePoints.Lp1, Order = 8, Price = 31 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Silver, DivisionType = DivisionTypes.Division2, PointsPerMatch = LeaguePoints.Lp1, Order = 9, Price = 31 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Silver, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp1, Order = 10, Price = 31 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Gold, DivisionType = DivisionTypes.Division5, PointsPerMatch = LeaguePoints.Lp1, Order = 11, Price = 34 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Gold, DivisionType = DivisionTypes.Division4, PointsPerMatch = LeaguePoints.Lp1, Order = 12, Price = 43 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Gold, DivisionType = DivisionTypes.Division3, PointsPerMatch = LeaguePoints.Lp1, Order = 13, Price = 43 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Gold, DivisionType = DivisionTypes.Division2, PointsPerMatch = LeaguePoints.Lp1, Order = 14, Price = 43 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Gold, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp1, Order = 15, Price = 43 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Platinum, DivisionType = DivisionTypes.Division5, PointsPerMatch = LeaguePoints.Lp1, Order = 16, Price = 48 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Platinum, DivisionType = DivisionTypes.Division4, PointsPerMatch = LeaguePoints.Lp1, Order = 17, Price = 52 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Platinum, DivisionType = DivisionTypes.Division3, PointsPerMatch = LeaguePoints.Lp1, Order = 18, Price = 52 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Platinum, DivisionType = DivisionTypes.Division2, PointsPerMatch = LeaguePoints.Lp1, Order = 19, Price = 52 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Platinum, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp1, Order = 20, Price = 52 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Diamond, DivisionType = DivisionTypes.Division5, PointsPerMatch = LeaguePoints.Lp1, Order = 21, Price = 70 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Diamond, DivisionType = DivisionTypes.Division4, PointsPerMatch = LeaguePoints.Lp1, Order = 22, Price = 92 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Diamond, DivisionType = DivisionTypes.Division3, PointsPerMatch = LeaguePoints.Lp1, Order = 23, Price = 103 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Diamond, DivisionType = DivisionTypes.Division2, PointsPerMatch = LeaguePoints.Lp1, Order = 24, Price = 108 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Diamond, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp1, Order = 25, Price = 114 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Master, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp1, Order = 26, Price = 235 });

            //add LeaguePoints.Lp2 prices
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Bronze, DivisionType = DivisionTypes.Division5, PointsPerMatch = LeaguePoints.Lp2, Order = 1, Price = 18 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Bronze, DivisionType = DivisionTypes.Division4, PointsPerMatch = LeaguePoints.Lp2, Order = 2, Price = 18 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Bronze, DivisionType = DivisionTypes.Division3, PointsPerMatch = LeaguePoints.Lp2, Order = 3, Price = 18 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Bronze, DivisionType = DivisionTypes.Division2, PointsPerMatch = LeaguePoints.Lp2, Order = 4, Price = 18 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Bronze, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp2, Order = 5, Price = 18 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Silver, DivisionType = DivisionTypes.Division5, PointsPerMatch = LeaguePoints.Lp2, Order = 6, Price = 21 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Silver, DivisionType = DivisionTypes.Division4, PointsPerMatch = LeaguePoints.Lp2, Order = 7, Price = 22 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Silver, DivisionType = DivisionTypes.Division3, PointsPerMatch = LeaguePoints.Lp2, Order = 8, Price = 22 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Silver, DivisionType = DivisionTypes.Division2, PointsPerMatch = LeaguePoints.Lp2, Order = 9, Price = 22 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Silver, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp2, Order = 10, Price = 22 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Gold, DivisionType = DivisionTypes.Division5, PointsPerMatch = LeaguePoints.Lp2, Order = 11, Price = 26 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Gold, DivisionType = DivisionTypes.Division4, PointsPerMatch = LeaguePoints.Lp2, Order = 12, Price = 32 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Gold, DivisionType = DivisionTypes.Division3, PointsPerMatch = LeaguePoints.Lp2, Order = 13, Price = 32 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Gold, DivisionType = DivisionTypes.Division2, PointsPerMatch = LeaguePoints.Lp2, Order = 14, Price = 32 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Gold, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp2, Order = 15, Price = 32 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Platinum, DivisionType = DivisionTypes.Division5, PointsPerMatch = LeaguePoints.Lp2, Order = 16, Price = 37 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Platinum, DivisionType = DivisionTypes.Division4, PointsPerMatch = LeaguePoints.Lp2, Order = 17, Price = 43 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Platinum, DivisionType = DivisionTypes.Division3, PointsPerMatch = LeaguePoints.Lp2, Order = 18, Price = 43 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Platinum, DivisionType = DivisionTypes.Division2, PointsPerMatch = LeaguePoints.Lp2, Order = 19, Price = 43 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Platinum, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp2, Order = 20, Price = 43 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Diamond, DivisionType = DivisionTypes.Division5, PointsPerMatch = LeaguePoints.Lp2, Order = 21, Price = 64 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Diamond, DivisionType = DivisionTypes.Division4, PointsPerMatch = LeaguePoints.Lp2, Order = 22, Price = 80 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Diamond, DivisionType = DivisionTypes.Division3, PointsPerMatch = LeaguePoints.Lp2, Order = 23, Price = 92 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Diamond, DivisionType = DivisionTypes.Division2, PointsPerMatch = LeaguePoints.Lp2, Order = 24, Price = 97 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Diamond, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp2, Order = 25, Price = 103 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Master, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp2, Order = 26, Price = 225 });

            //add LeaguePoints.Lp3 prices
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Bronze, DivisionType = DivisionTypes.Division5, PointsPerMatch = LeaguePoints.Lp3, Order = 1, Price = 16 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Bronze, DivisionType = DivisionTypes.Division4, PointsPerMatch = LeaguePoints.Lp3, Order = 2, Price = 16 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Bronze, DivisionType = DivisionTypes.Division3, PointsPerMatch = LeaguePoints.Lp3, Order = 3, Price = 16 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Bronze, DivisionType = DivisionTypes.Division2, PointsPerMatch = LeaguePoints.Lp3, Order = 4, Price = 16 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Bronze, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp3, Order = 5, Price = 16 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Silver, DivisionType = DivisionTypes.Division5, PointsPerMatch = LeaguePoints.Lp3, Order = 6, Price = 19 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Silver, DivisionType = DivisionTypes.Division4, PointsPerMatch = LeaguePoints.Lp3, Order = 7, Price = 21 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Silver, DivisionType = DivisionTypes.Division3, PointsPerMatch = LeaguePoints.Lp3, Order = 8, Price = 21 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Silver, DivisionType = DivisionTypes.Division2, PointsPerMatch = LeaguePoints.Lp3, Order = 9, Price = 21 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Silver, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp3, Order = 10, Price = 21 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Gold, DivisionType = DivisionTypes.Division5, PointsPerMatch = LeaguePoints.Lp3, Order = 11, Price = 24 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Gold, DivisionType = DivisionTypes.Division4, PointsPerMatch = LeaguePoints.Lp3, Order = 12, Price = 31 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Gold, DivisionType = DivisionTypes.Division3, PointsPerMatch = LeaguePoints.Lp3, Order = 13, Price = 31 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Gold, DivisionType = DivisionTypes.Division2, PointsPerMatch = LeaguePoints.Lp3, Order = 14, Price = 31 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Gold, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp3, Order = 15, Price = 31 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Platinum, DivisionType = DivisionTypes.Division5, PointsPerMatch = LeaguePoints.Lp3, Order = 16, Price = 35 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Platinum, DivisionType = DivisionTypes.Division4, PointsPerMatch = LeaguePoints.Lp3, Order = 17, Price = 40 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Platinum, DivisionType = DivisionTypes.Division3, PointsPerMatch = LeaguePoints.Lp3, Order = 18, Price = 40 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Platinum, DivisionType = DivisionTypes.Division2, PointsPerMatch = LeaguePoints.Lp3, Order = 19, Price = 40 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Platinum, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp3, Order = 20, Price = 40 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Diamond, DivisionType = DivisionTypes.Division5, PointsPerMatch = LeaguePoints.Lp3, Order = 21, Price = 60 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Diamond, DivisionType = DivisionTypes.Division4, PointsPerMatch = LeaguePoints.Lp3, Order = 22, Price = 80 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Diamond, DivisionType = DivisionTypes.Division3, PointsPerMatch = LeaguePoints.Lp3, Order = 23, Price = 92 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Diamond, DivisionType = DivisionTypes.Division2, PointsPerMatch = LeaguePoints.Lp3, Order = 24, Price = 97 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Diamond, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp3, Order = 25, Price = 103 });
            _context.Prices.Add(new Prices { LeagueType = LeagueTypes.Master, DivisionType = DivisionTypes.Division1, PointsPerMatch = LeaguePoints.Lp3, Order = 26, Price = 180 });

            //save changes
            _context.SaveChanges();
        }
    }
}
