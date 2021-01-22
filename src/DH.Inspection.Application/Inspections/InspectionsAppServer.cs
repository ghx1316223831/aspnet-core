using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using DH.Inspection.Inspections.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DH.Inspection.Inspections
{
    public class InspectionsAppServer: AsyncCrudAppService<Inspections, InspectionsDto, int, PagedInspectionsResultRequestDto, InspectionsDto, InspectionsDto>,IInspectionsAppServer
    {
        public InspectionsAppServer(IRepository<Inspections> repository
            )
            : base(repository)
        {

        }
    }
}
