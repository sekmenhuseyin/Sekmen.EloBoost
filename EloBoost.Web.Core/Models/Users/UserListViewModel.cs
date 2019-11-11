using EloBoost.Roles.Dto;
using EloBoost.Users.Dto;
using System.Collections.Generic;

namespace EloBoost.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
