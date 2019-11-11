using EloBoost.Shared.Enums;

namespace EloBoost.EntityFrameworkCore.Seed.Tenants
{
    public class DefaultUsers
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Passsword { get; set; }
        public UserType UserType { get; set; }
        public int RoleId { get; set; }
    }
}