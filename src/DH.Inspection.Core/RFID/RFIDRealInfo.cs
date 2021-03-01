using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DH.Inspection.RFID
{
    /// <summary>
    /// 电子标签实时数据信息表
    /// </summary>
    public class RFIDRealInfo
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        [MaxLength(8)]//最大长度
        [Required]//必须填字段
        public long TcmsTimeStamp { get; set; }

        /// <summary>
        /// 电子标签名称
        /// </summary>
        [MaxLength(128)]//最大长度
        [Required]//必须填字段
        public string RFIDName { get; set; }

        /// <summary>
        /// 当前列基础信息唯一代码
        /// </summary>
        [MaxLength(36)]//最大长度
        [Required]//必须填字段
        public string TrainOperation { get; set; }

        /// <summary>
        /// 备用字段
        /// </summary>
        [MaxLength(128)]//最大长度
        public string Standby { get; set; }

    }
}
