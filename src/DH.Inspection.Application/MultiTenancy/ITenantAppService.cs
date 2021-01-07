using Abp.Application.Services;
using DH.Inspection.MultiTenancy.Dto;

namespace DH.Inspection.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

