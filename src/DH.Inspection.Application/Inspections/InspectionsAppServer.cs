using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using DH.Inspection.Inspections.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DH.Inspection.Inspections
{
    public class InspectionsAppServer : AsyncCrudAppService<Inspections, InspectionsDto, int, PagedInspectionsResultRequestDto, InspectionsDto, InspectionsDto>, IInspectionsAppServer
    {
        public InspectionsAppServer(IRepository<Inspections> repository
            )
            : base(repository)
        {

        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        public async Task<ListResultDto<InspectionsDto>> GetInspectionsList()
        {
            List<InspectionsDto> list = new List<InspectionsDto>();
            var rest = await Repository.GetAll()
                .ToListAsync();
            return new ListResultDto<InspectionsDto>(ObjectMapper.Map<List<InspectionsDto>>(rest));
        }
        public async Task<InspectionsDto> MapToEntityDto(InspectionsDto dto)
        {

            InspectionsDto dto1 = new InspectionsDto();

            return dto;
        }
        
    }


    public class InspectionsAppServers : AsyncCrudAppService<Inspection, IInspectionsDto, string, PagedInspectionsResultRequestDto, IInspectionsDto, IInspectionsDto>, IIInspectionsAppServer
    {
        public InspectionsAppServers(IRepository<Inspection, string> repositorys
            )
            : base((IRepository<Inspection, string>)repositorys)
        {

        }

    }
}
