using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DH.Inspection.SystemSelfTest
{
    /// <summary>
    /// 自检信息数据表
    /// </summary>
    public class SystemSelfTestInfo
    {
        /// <summary>
        /// 运行编码（GUID）（具备唯一性）
        /// </summary>
        [MaxLength(36)]//最大长度
        [Required]//必须填字段
        public string TestCode { get; set; }
        /// <summary>
        /// 当前列开始的时间
        /// </summary>
        [Required]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 当前列结束时间
        /// </summary>
        public DateTime EndTime { get; set; }

        //TestInfo int	4	是	-1异常，0正常-2D左轮廓传感器-内
        //-2异常，0正常-2D左轮廓传感器-外
        //-3异常，0正常-补偿轮廓传感器
        //-4异常，0正常-2D右轮廓传感器-内
        //-5异常，0正常-2D右轮廓传感器-外
        //-6异常，0正常-车体横向加速度
        //-7异常，0正常-车体纵向加速度
        //-8异常，0正常-左高低传感器
        //-9异常，0正常-右高低传感器
        //-10异常，0正常-水平陀螺仪
        //-11异常，0正常-垂向陀螺仪
        //-12异常，0正常-倾角传感器
        //-13异常，0正常-轨向加速度
        //-14异常，0正常-左巡检相机外侧
        //-15异常，0正常-左巡检相机内测
        //-16异常，0正常-右巡检相机外侧
        //-17异常，0正常-右巡检相机内测
        //-18异常，0正常-电子标签读卡器
        //系统状态正常-0，否则其它值

        /// <summary>
        /// 备用字段
        /// </summary>
        [MaxLength(128)]//最大长度
        public string Standby { get; set; }

    }
}
