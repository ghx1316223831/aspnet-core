using System.Threading.Tasks;
using DH.Inspection.Configuration.Dto;

namespace DH.Inspection.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
