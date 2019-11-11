using EloBoost.Roles.Dto;
using System.Collections.Generic;

namespace EloBoost.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}