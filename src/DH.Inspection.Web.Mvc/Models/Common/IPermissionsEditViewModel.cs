using System.Collections.Generic;
using DH.Inspection.Roles.Dto;

namespace DH.Inspection.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }

        List<DH.Inspection.Authorization.Permissions.Dto.FlatPermissionWithLevelDto> PermissionsTree { get; set; }
    }
}