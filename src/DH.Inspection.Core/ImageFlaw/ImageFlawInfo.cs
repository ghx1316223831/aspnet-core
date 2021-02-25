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
        /// 病害类型：
        ///1-扣件缺失 2-弹条断裂 3-弹条移位 4-钢轨表面擦伤
        ///5-钢轨表面剥离 6-轨枕开裂 7-轨枕翻浆冒泥 8-道床异物 9-道钉缺失
        /// </summary>
        [MaxLength(4)]
        public EnumFlawType FlawType { get; set; }
    }
}
