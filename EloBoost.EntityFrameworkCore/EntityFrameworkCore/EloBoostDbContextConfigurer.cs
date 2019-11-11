using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace EloBoost.EntityFrameworkCore
{
    public static class EloBoostDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<EloBoostDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<EloBoostDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
