using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using DH.Inspection.Line.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DH.Inspection.Line
{
    public class LineInfoAppServer : AsyncCrudAppService<LineInfo, LineInfoDto, int, PagedResultRequestDto, LineInfoDto, LineInfoDto>, ILineInfoAppServer
    {
        public LineInfoAppServer(IRepository<LineInfo> repository
           ) : base(repository)
        {

        }


    }
}
