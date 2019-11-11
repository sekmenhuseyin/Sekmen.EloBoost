using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EloBoost.Configuration;

namespace EloBoost.Web.Host.Startup
{
    [DependsOn(
       typeof(EloBoostWebCoreModule))]
    public class EloBoostWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public EloBoostWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EloBoostWebHostModule).GetAssembly());
        }
    }
}
