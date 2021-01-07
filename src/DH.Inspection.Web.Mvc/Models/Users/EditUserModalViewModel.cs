using System.Collections.Generic;
using System.Linq;
using DH.Inspection.Roles.Dto;
using DH.Inspection.Users.Dto;

namespace DH.Inspection.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.RoleNames != null && User.RoleNames.Any(r => r == role.NormalizedName);
        }
    }
}
