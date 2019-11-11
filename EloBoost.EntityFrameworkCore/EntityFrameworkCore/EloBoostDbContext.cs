using Abp.Zero.EntityFrameworkCore;
using EloBoost.Authorization.Roles;
using EloBoost.Authorization.Users;
using EloBoost.Boosters;
using EloBoost.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace EloBoost.EntityFrameworkCore
{
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class EloBoostDbContext : AbpZeroDbContext<Tenant, Role, User, EloBoostDbContext>
    {
        public EloBoostDbContext(DbContextOptions<EloBoostDbContext> options)
            : base(options)
        {
        }

        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersHistory> OrdersHistory { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Prices> Prices { get; set; }
    }
}
