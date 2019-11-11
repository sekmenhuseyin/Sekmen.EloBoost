using Abp.Authorization;
using Abp.Localization;

namespace EloBoost.Authorization
{
    public class EloBoostAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.PagesUsers, L("Users"));
            context.CreatePermission(PermissionNames.PagesRoles, L("Roles"));
            context.CreatePermission(PermissionNames.PagesSelect, L("Select"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, EloBoostConsts.LocalizationSourceName);
        }
    }
}
