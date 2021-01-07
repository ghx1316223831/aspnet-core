using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using DH.Inspection.Configuration.Dto;

namespace DH.Inspection.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : InspectionAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
