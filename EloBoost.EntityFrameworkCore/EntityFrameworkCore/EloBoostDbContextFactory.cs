using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using EloBoost.Configuration;
using EloBoost.Web;

namespace EloBoost.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class EloBoostDbContextFactory : IDesignTimeDbContextFactory<EloBoostDbContext>
    {
        public EloBoostDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<EloBoostDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            EloBoostDbContextConfigurer.Configure(builder, configuration.GetConnectionString(EloBoostConsts.ConnectionStringName));

            return new EloBoostDbContext(builder.Options);
        }
    }
}
