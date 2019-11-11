using Abp.MultiTenancy;
using Abp.Zero.Configuration;

namespace EloBoost.Authorization.Roles
{
    public static class AppRoleConfig
    {
        public static void Configure(IRoleManagementConfig roleManagementConfig)
        {
            // Static host roles
            roleManagementConfig.StaticRoles.Add(new StaticRoleDefinition(StaticRoleNames.Admin, MultiTenancySides.Host));
            // Static tenant roles
            roleManagementConfig.StaticRoles.Add(new StaticRoleDefinition(StaticRoleNames.Admin, MultiTenancySides.Tenant));
        }
    }
}