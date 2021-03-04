using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DH.Inspection.Share
{
    public class EnumData
    {
        public enum EnumFlawType : byte
        {
            /// <summary>
            /// 扣件缺失
            /// </summary>
            [Description("扣件缺失")]
            FastenerMissing = 1,
            /// <summary>
            /// 弹条断裂
            /// </summary>
            [Description("弹条断裂")]
            SpringBarCrack = 2,
            /// <summary>
            /// 弹条移位
            /// </summary>
            [Description("弹条移位")]
            SpringBarShift = 3,

            /// <summary>
            /// 钢轨表面擦伤
            /// </summary>
            [Description("钢轨表面擦伤")]
            RailSurfaceScratch = 4,

            /// <summary>
            /// 钢轨表面剥离
            /// </summary>
            [Description("钢轨表面剥离")]
            RailSurfacePeeling = 5,

            /// <summary>
            /// 轨枕开裂
            /// </summary>
            [Description("轨枕开裂")]
            SleeperCracking = 6,

            /// <summary>
            /// 轨枕翻浆冒泥
            /// </summary>
            [Description("轨枕翻浆冒泥")]
            SleeperMudPumping = 7,
            /// <summary>
            /// 道床异物
            /// </summary>
            [Description("道床异物")]
            BallastForeignMatter = 8,
            /// <summary>
            /// 轨枕翻浆冒泥
            /// </summary>
            [Description("轨枕翻浆冒泥")]
            MissingSpike = 9

        }

    }
}
