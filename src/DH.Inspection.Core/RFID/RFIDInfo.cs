using DH.Inspection.Line;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DH.Inspection.RFID
{
    /// <summary>
    /// 电子标签基础信息表
    /// </summary>
    public class RFIDInfo
    {
        /// <summary>
        /// 运行编码（GUID）（具备唯一性）
        /// </summary>
        [MaxLength(128)]//最大长度
        [Required]//必须填字段
        public string RFIDName { get; set; }
        /// <summary>
        /// 上下行标志 1-上行，0-下行。
        /// </summary>
        [MaxLength(4)]
        public int UpOrDwon { get; set; }
        /// <summary>
        /// 线路id
        /// </summary>
        [MaxLength(4)]
        public int LineID { get; set; }

        public virtual LineInfo LineInfo { get; set; }

        /// <summary>
        /// 开始站区ID
        /// </summary>
        [MaxLength(4)]
        public int StartStationID { get; set; }

        /// <summary>
        /// 结束站区ID
        /// </summary>
        [MaxLength(4)]
        public int EndStationID { get; set; }

        /// <summary>
        /// 公里标
        /// </summary>
        [MaxLength(4)]
        [Required]
        public Double Mark { get; set; }
        /// <summary>
        /// 备用字段
        /// </summary>
        [MaxLength(128)]//最大长度
        public string Standby { get; set; }

    }
}
