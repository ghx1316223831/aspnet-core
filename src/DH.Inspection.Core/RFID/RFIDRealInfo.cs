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
        [MaxLength(8)]//最大长度
        [Required]//必须填字段
        public long TcmsTimeStamp { get; set; }

        [MaxLength(128)]//最大长度
        [Required]//必须填字段
        public string RFIDName { get; set; }
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
