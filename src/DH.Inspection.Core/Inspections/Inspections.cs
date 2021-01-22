﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace DH.Inspection.Inspections
{
    /// <summary>
    /// 巡检
    /// </summary>
    public class Inspections : AuditedEntity
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
