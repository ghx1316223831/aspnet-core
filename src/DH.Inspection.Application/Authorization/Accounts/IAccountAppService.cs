using System.Threading.Tasks;
using Abp.Application.Services;
using DH.Inspection.Authorization.Accounts.Dto;

namespace DH.Inspection.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
