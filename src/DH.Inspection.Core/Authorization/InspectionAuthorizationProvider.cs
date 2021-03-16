using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using System.Collections.Generic;

namespace DH.Inspection.Authorization
{
    public class InspectionAuthorizationProvider : AuthorizationProvider
    {

        private readonly bool _isMultiTenancyEnabled;
        public InspectionAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public InspectionAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        /// <summary>
        /// 权限配置
        /// </summary>
        /// <param name="context"></param>
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            var pages = context.GetPermissionOrNull(PermissionNames.Pages) ?? context.CreatePermission(PermissionNames.Pages, L("Pages"), properties: new Dictionary<string, object> { { "Sequence", 1 }, { "id", "3" } });
            var HomeIndex = pages.CreateChildPermission(PermissionNames.Pages_Home, L("Home"), properties: new Dictionary<string, object> { { "Sequence", 1 }, { "id", "3" } });
            //HomeIndex.CreateChildPermission(PermissionNames.Pages_Home_index, L("System"), properties: new Dictionary<string, object> { { "Sequence", 1 }, { "id", "3" } });


            var system = pages.CreateChildPermission(PermissionNames.Pages_Sys, L("System"), properties: new Dictionary<string, object> { { "Sequence", 10 }, { "id", "4" } });
            system.CreateChildPermission(PermissionNames.Pages_Sys_SysUser, L("Users"), properties: new Dictionary<string, object> { { "Sequence", 10 }, { "id", "4" } });
            system.CreateChildPermission(PermissionNames.Pages_Sys_Role, L("Roles"), properties: new Dictionary<string, object> { { "Sequence", 10 }, { "id", "4" } });



           
            pages.CreateChildPermission(PermissionNames.Pages_InspectionReport, L("InspectionReport"), properties: new Dictionary<string, object> { { "Sequence", 11 }, { "id", "5" } });
            //context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            var dam = pages.CreateChildPermission(PermissionNames.Pages_DataAcquisitionModule, L("DataAcquisitionModule"), properties: new Dictionary<string, object> { { "Sequence", 2 }, { "id", "2" } });
            dam.CreateChildPermission(PermissionNames.Pages_DataAcquisitionModule_Images, L("Images"), properties: new Dictionary<string, object> { { "Sequence", 2 }, { "id", "2" } });
            dam.CreateChildPermission(PermissionNames.Pages_DataAcquisitionModule_TCMS, L("TCMS"), properties: new Dictionary<string, object> { { "Sequence", 2 }, { "id", "2" } });
            


        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, InspectionConsts.LocalizationSourceName);
        }
    }
}
