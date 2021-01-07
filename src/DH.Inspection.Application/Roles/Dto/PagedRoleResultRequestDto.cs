using Abp.Application.Services.Dto;

namespace DH.Inspection.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

