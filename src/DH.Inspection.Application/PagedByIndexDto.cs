using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DH.Inspection
{
    /// <summary>
    /// 分页参数基类，传页码，从0开始。使用这个类，那么传的SkipCount就不使用，计算得出SkipCount。
    /// </summary>
    public class PagedByIndexDto : PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }
        public string? Keyword { get; set; }
        public override int SkipCount { get => base.SkipCount = PageIndex * base.MaxResultCount; set => base.SkipCount = value; }
    }
}
