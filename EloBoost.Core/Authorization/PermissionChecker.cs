using Abp.Authorization;
using EloBoost.Authorization.Roles;
using EloBoost.Authorization.Users;

namespace EloBoost.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
