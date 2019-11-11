using Abp.Application.Navigation;
using Abp.Localization;
using EloBoost.Authorization;

namespace EloBoost.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class EloBoostNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(new MenuItemDefinition(PageNames.Home, L("HomePage"), url: "DashBoard", icon: "home", requiresAuthentication: true))
                .AddItem(new MenuItemDefinition(PageNames.Users, L("Users"), url: "Users", icon: "people", requiredPermissionName: PermissionNames.PagesUsers))
                .AddItem(new MenuItemDefinition(PageNames.Roles, L("Roles"), url: "Roles", icon: "local_offer", requiredPermissionName: PermissionNames.PagesRoles))
                .AddItem(new MenuItemDefinition(PageNames.Select, L("SelectOrder"), url: "Select", icon: "info", requiredPermissionName: PermissionNames.PagesSelect))
                .AddItem(new MenuItemDefinition(PageNames.Orders, L("MyOrders"), url: "Orders", icon: "info", requiresAuthentication: true))
                .AddItem(new MenuItemDefinition(PageNames.Purchase, L("Purchase"), url: "Purchase", icon: "info", requiresAuthentication: true))
                .AddItem(new MenuItemDefinition(PageNames.Profile, L("MyAccount"), url: "Profile", icon: "info", requiresAuthentication: true))
                .AddItem(new MenuItemDefinition(PageNames.About, L("About"), url: "About", icon: "info"))
                .AddItem(new MenuItemDefinition(PageNames.Logout, L("Logout"), url: "Account/Logout", icon: "input"))
            ;
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, EloBoostConsts.LocalizationSourceName);
        }
    }
}
