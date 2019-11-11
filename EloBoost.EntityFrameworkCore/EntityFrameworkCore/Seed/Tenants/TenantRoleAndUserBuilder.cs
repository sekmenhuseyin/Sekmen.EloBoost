using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using EloBoost.Authorization;
using EloBoost.Authorization.Roles;
using EloBoost.Authorization.Users;
using EloBoost.Shared.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace EloBoost.EntityFrameworkCore.Seed.Tenants
{
    public class TenantRoleAndUserBuilder
    {
        private readonly EloBoostDbContext _context;
        private readonly int _tenantId;

        public TenantRoleAndUserBuilder(EloBoostDbContext context)
        {
            _context = context;
            _tenantId = 1;
        }

        public void Create()
        {
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            // Admin role

            var allRoles = _context.Roles.IgnoreQueryFilters().ToList();
            var adminRole = new Role();
            var coachRole = new Role();
            var boosterRole = new Role();
            if (allRoles.Count == 0)
            {
                //admin role
                adminRole = _context.Roles.Add(new Role(_tenantId, StaticRoleNames.Admin, StaticRoleNames.Admin) { IsStatic = true }).Entity;
                _context.SaveChanges();
                //coach role
                coachRole = _context.Roles.Add(new Role(_tenantId, StaticRoleNames.Coach, StaticRoleNames.Coach) { IsStatic = true }).Entity;
                _context.SaveChanges();
                //player role
                boosterRole = _context.Roles.Add(new Role(_tenantId, StaticRoleNames.Booster, StaticRoleNames.Booster) { IsStatic = true }).Entity;
                _context.SaveChanges();
            }
            else
            {
                adminRole = allRoles.FirstOrDefault(m => m.Id == 1) ?? new Role();
                coachRole = allRoles.FirstOrDefault(m => m.Id == 2) ?? new Role();
                boosterRole = allRoles.FirstOrDefault(m => m.Id == 3) ?? new Role();
            }

            // Grant all permissions to admin role
            var grantedPermissions = _context.Permissions.IgnoreQueryFilters().OfType<RolePermissionSetting>().Where(p => p.TenantId == _tenantId && p.RoleId == adminRole.Id).Select(p => p.Name).ToList();
            var permissions = PermissionFinder.GetAllPermissions(new EloBoostAuthorizationProvider()).Where(p => p.MultiTenancySides.HasFlag(MultiTenancySides.Tenant) && !grantedPermissions.Contains(p.Name)).ToList();
            if (permissions.Any())
            {
                _context.Permissions.AddRange(permissions.Select(permission => new RolePermissionSetting { TenantId = _tenantId, Name = permission.Name, IsGranted = true, RoleId = adminRole.Id }));
                _context.SaveChanges();
            }

            // Grant all permissions to admin role
            grantedPermissions = _context.Permissions.IgnoreQueryFilters().OfType<RolePermissionSetting>().Where(p => p.TenantId == _tenantId && (p.RoleId == boosterRole.Id || p.RoleId == coachRole.Id)).Select(p => p.Name).ToList();
            if (!grantedPermissions.Any())
            {
                _context.Permissions.Add(new RolePermissionSetting { TenantId = _tenantId, Name = PermissionNames.PagesSelect, IsGranted = true, RoleId = coachRole.Id });
                _context.Permissions.Add(new RolePermissionSetting { TenantId = _tenantId, Name = PermissionNames.PagesSelect, IsGranted = true, RoleId = boosterRole.Id });
                _context.SaveChanges();
            }

            // users
            var firstUser = _context.Users.IgnoreQueryFilters().FirstOrDefault();
            if (firstUser != null) return;
            var defaultUsers = new List<DefaultUsers>
            {
                new DefaultUsers { Username = "root", Email = "root@huseyinsekmenoglu.net", Passsword = "Elo.Boost!v1", UserType = UserType.Admin, RoleId = adminRole.Id },
                new DefaultUsers { Username = "admin", Email = "admin@huseyinsekmenoglu.net", Passsword = "123qwe", UserType = UserType.Admin, RoleId = adminRole.Id },
                new DefaultUsers { Username = "coach", Email = "coach@huseyinsekmenoglu.net", Passsword = "123qwe", UserType = UserType.Coach, RoleId = coachRole.Id },
                new DefaultUsers { Username = "player", Email = "player@huseyinsekmenoglu.net", Passsword = "123qwe", UserType = UserType.Booster, RoleId = boosterRole.Id },
                new DefaultUsers { Username = "user", Email = "user@huseyinsekmenoglu.net", Passsword = "123qwe", UserType = UserType.User }
            };
            //insert users
            foreach (var item in defaultUsers)
            {
                firstUser = User.CreateTenantAdminUser(item.Username, item.Email, item.UserType);
                firstUser.Password = new PasswordHasher<User>(new OptionsWrapper<PasswordHasherOptions>(new PasswordHasherOptions())).HashPassword(firstUser, item.Passsword);
                //save
                _context.Users.Add(firstUser);
                _context.SaveChanges();
                if (item.RoleId == 0) continue;
                // Assign Admin role to user
                _context.UserRoles.Add(new UserRole(_tenantId, firstUser.Id, item.RoleId));
                _context.SaveChanges();
            }
        }
    }
}