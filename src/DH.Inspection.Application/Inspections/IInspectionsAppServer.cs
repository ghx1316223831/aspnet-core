using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DH.Inspection.Inspections.Dto;

namespace DH.Inspection.Inspections
{
    public interface IInspectionsAppServer : IAsyncCrudAppService<InspectionsDto, int, PagedInspectionsResultRequestDto, InspectionsDto, InspectionsDto>
    {


    }
    public interface IIInspectionsAppServer : IAsyncCrudAppService<IInspectionsDto, string, PagedInspectionsResultRequestDto, IInspectionsDto, IInspectionsDto>
    {


    }
}
 