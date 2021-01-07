using System.Collections.Generic;
using DH.Inspection.Roles.Dto;

namespace DH.Inspection.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
