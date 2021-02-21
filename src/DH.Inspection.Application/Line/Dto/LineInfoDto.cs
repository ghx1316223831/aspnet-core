using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DH.Inspection.Line.Dto
{
    /// <summary>
    /// 巡检
    /// </summary>
    [AutoMap(typeof(LineInfo))]
    public class LineInfoDto : EntityDto
    {
        /// <summary>
        /// 线路ID
        /// </summary>
        
        public int LineID { get; set; }

        /// <summary>
        /// 线路名称
        /// </summary>
        public string LineName { get; set; }
    }
}
