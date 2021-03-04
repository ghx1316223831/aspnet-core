using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DH.Inspection.TCMS
{
    /// <summary>
    /// TCMS数据表
    /// </summary>
    public class TCMSInfo
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        [MaxLength(8)]//最大长度
        [Required]//必须填字段
        public long TcmsTimeStamp { get; set; }

        /// <summary>
        /// 速度信息
        /// </summary>
        [MaxLength(8)]
        [Required]
        public double Speed { get; set; }

        /// <summary>
        /// 总里程信息
        /// </summary>
        [MaxLength(8)]
        [Required]
        public double TotalKM { get; set; }

        /// <summary>
        /// 车辆开门信息
        /// </summary>
        [MaxLength(4)]
        public int TrainOpenDoor { get; set; }

        /// <summary>
        /// 车辆关门信息
        /// </summary>
        [MaxLength(4)]
        public int TrainCloseDoor { get; set; }

        /// <summary>
        /// 车辆移动信息
        /// </summary>
        [MaxLength(4)]
        public int TrainStartMove { get; set; }

        /// <summary>
        /// 车辆停止信息
        /// </summary>
        [MaxLength(4)]
        public int TrainStopMove { get; set; }

        /// <summary>
        /// 站区ID
        /// </summary>
        [MaxLength(4)]
        public int StationID { get; set; }
        /// <summary>
        /// 公里标
        /// </summary>
        [MaxLength(8)]
        [Required]
        public double Mark { get; set; }

        /// <summary>
        /// 当前列基础信息唯一代码
        /// </summary>
        [MaxLength(36)]
        [Required]
        public string TrainOperation { get; set; }

        /// <summary>
        /// 备用字段
        /// </summary>
        [MaxLength(128)]
        public string Standby { get; set; }

    }
}
