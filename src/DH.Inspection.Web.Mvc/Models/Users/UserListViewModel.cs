using System.Collections.Generic;
using DH.Inspection.Roles.Dto;

namespace DH.Inspection.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
