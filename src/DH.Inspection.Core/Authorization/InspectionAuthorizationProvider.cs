using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace DH.Inspection.Authorization
{
    public class InspectionAuthorizationProvider : AuthorizationProvider
    {
        /// <summary>
        /// 权限配置
        /// </summary>
        /// <param name="context"></param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            //context.CreatePermission(PermissionNames.Pages_GHX, L("Ghx"));
            context.CreatePermission(PermissionNames.Pages_InspectionReport, L("InspectionReport"));
            context.CreatePermission(PermissionNames.Pages_Home, L("Home"));
            //context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, InspectionConsts.LocalizationSourceName);
        }
    }
}
