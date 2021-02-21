using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DH.Inspection.Line
{
    /// <summary>
    /// 列车运行表
    /// </summary>
    public class TrainOperationInfo
    {
        /// <summary>
        /// 运行编码（GUID）
        /// </summary>
        [MaxLength(36)]//最大长度
        [Required]//必须填字段
        public string Code { get; set; }

        /// <summary>
        /// 线路id
        /// </summary>
        [MaxLength(4)]
        [Required]
        public int LineID { get; set; }

        public virtual LineInfo LineInfo { get; set; }

        /// <summary>
        /// 线路名称
        /// </summary>
        [MaxLength(128)]//最大长度
        [Required]//必须填字段
        public string LineName { get; set; }

        /// <summary>
        /// 起始公里标
        /// </summary>
        [MaxLength(4)]
        [Required]
        public Double StartMark { get; set; }

        /// <summary>
        /// 结束公里标
        /// </summary>
        [MaxLength(4)]
        [Required]
        public Double EndMark { get; set; }

        /// <summary>
        /// 当前列开始的时间
        /// </summary>
        [Required]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 当前列结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 上下行标志 1-上行，0-下行。
        /// </summary>
        [MaxLength(4)]
        [Required]
        public int UpOrDwon { get; set; }

        /// <summary>
        /// 车次
        /// </summary>
        [MaxLength(4)]
        [Required]
        public int TrainNumber { get; set; }

        /// <summary>
        /// 列车号（名）
        /// </summary>
        [MaxLength(4)]//最大长度
        [Required]
        public int TrainName { get; set; }

        /// <summary>
        /// 备用字段
        /// </summary>
        [MaxLength(128)]//最大长度
        public string Standby { get; set; }

    }
}
