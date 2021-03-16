using DH.Inspection.Authorization.Permissions.Dto;
using System.Collections.Generic;

namespace DH.Inspection.Roles.Dto
{
    public class GetRoleForEditOutput
    {
        public RoleEditDto Role { get; set; }

        public List<FlatPermissionDto> Permissions { get; set; }
        public List<DH.Inspection.Authorization.Permissions.Dto.FlatPermissionWithLevelDto> PermissionsTree { get; set; }
        public List<string> GrantedPermissionNames { get; set; }

    }
}