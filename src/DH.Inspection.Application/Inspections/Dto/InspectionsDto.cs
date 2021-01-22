using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DH.Inspection.Inspections.Dto
{
    /// <summary>
    /// 巡检
    /// </summary>
    public class InspectionsDto : EntityDto<int>
    {
        /// <summary>
        /// 名字
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 名字
        /// </summary>
        public string phone { get; set; }


    }
}
