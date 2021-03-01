using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DH.Inspection.Image
{
    /// <summary>
    /// 图像数据表
    /// </summary>
    public class ImageInfo
    {
        /// <summary>
        /// 时间戳
        /// </summary>
        [MaxLength(8)]//最大长度
        [Required]//必须填字段
        public long TcmsTimeStamp { get; set; }


        /// <summary>
        /// 速度
        /// </summary>
        [MaxLength(8)]//最大长度
        [Required]
        public double Speed { get; set; }

        /// <summary>
        /// 站区ID
        /// </summary>
        [MaxLength(4)]//最大长度
        public int StationID { get; set; }

        /// <summary>
        /// 图片路径信息
        /// </summary>
        [MaxLength(512)]//最大长度
        [Required]
        public string ImagePath { get; set; }

        /// <summary>
        /// 公里标
        /// </summary>
        [MaxLength(8)]//最大长度
        public double Mark { get; set; }

        /// <summary>
        /// 当前列基础信息唯一代码
        /// </summary>
        [MaxLength(36)]//最大长度
        [Required]
        public string TrainOperation { get; set; }

        /// <summary>
        /// 备用字段
        /// </summary>
        [MaxLength(128)]//最大长度
        public string Standby { get; set; }

    }
}
