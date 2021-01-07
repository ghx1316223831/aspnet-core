using Abp.Authorization;
using DH.Inspection.Authorization.Roles;
using DH.Inspection.Authorization.Users;

namespace DH.Inspection.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
