using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EloBoost.Authorization;

namespace EloBoost
{
    [DependsOn(
        typeof(EloBoostCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class EloBoostApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<EloBoostAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(EloBoostApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
