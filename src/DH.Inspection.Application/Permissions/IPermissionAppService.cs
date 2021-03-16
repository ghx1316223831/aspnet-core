using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DH.Inspection.Authorization.Permissions.Dto;

namespace DH.Inspection.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
