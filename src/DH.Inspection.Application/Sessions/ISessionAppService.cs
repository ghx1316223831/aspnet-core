using System.Threading.Tasks;
using Abp.Application.Services;
using DH.Inspection.Sessions.Dto;

namespace DH.Inspection.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
