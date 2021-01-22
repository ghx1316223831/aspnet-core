using Abp.Application.Services.Dto;

namespace DH.Inspection.Inspections.Dto
{
    public class PagedInspectionsResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
