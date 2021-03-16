using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using DH.Inspection.Authorization;

namespace DH.Inspection.Web.Startup
{
    /// <summary>
    /// 菜单列表
    /// </summary>
    public class InspectionNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fas fa-home",
                        requiresAuthentication: true
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.InspectionReport,
                        L("InspectionReport"),
                        url: "InspectionReport/Index",
                        icon: "fas fa-theater-masks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_InspectionReport)
                            )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.System,
                        L("权限系统"),
                        icon: "fas fa-circle",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Sys)
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Users,
                            L("Users"),
                            url: "Users/Index",
                            icon: "fas fa-users",
                            permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Sys_SysUser)
                        )
                    ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "fas fa-theater-masks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Sys_Role)
                            )
                    )
                )
                
                /*.AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants",
                        icon: "fas fa-building",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Tenants)
                    )
                )*/
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "About",
                        icon: "fas fa-info-circle"
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, InspectionConsts.LocalizationSourceName);
        }
    }
}
