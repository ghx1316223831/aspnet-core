using Abp.AutoMapper;
using DH.Inspection.Roles.Dto;
using DH.Inspection.Web.Models.Common;

namespace DH.Inspection.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
        public bool HasPermission(DH.Inspection.Authorization.Permissions.Dto.FlatPermissionWithLevelDto permissionsTree)
        {
            return GrantedPermissionNames.Contains(permissionsTree.Name);
        }

    }
}
