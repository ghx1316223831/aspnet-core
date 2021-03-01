using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static DH.Inspection.Share.EnumData;

namespace DH.Inspection.ImageFlaw
{
    /// <summary>
    /// 缺陷数据信息表
    /// </summary>
    public class ImageFlawInfo
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
        /// 病害类型：
        ///1-扣件缺失 2-弹条断裂 3-弹条移位 4-钢轨表面擦伤
        ///5-钢轨表面剥离 6-轨枕开裂 7-轨枕翻浆冒泥 8-道床异物 9-道钉缺失
        /// </summary>
        [MaxLength(4)]
        public EnumFlawType FlawType { get; set; }

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
