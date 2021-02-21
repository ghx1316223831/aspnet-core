using Abp.Application.Services;
using Abp.Application.Services.Dto;
using DH.Inspection.Line.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DH.Inspection.Line
{
    public interface ILineInfoAppServer : IAsyncCrudAppService<LineInfoDto, int, PagedResultRequestDto, LineInfoDto, LineInfoDto>
    {

    }
}
