using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DH.Inspection.Line
{
    /// <summary>
    /// 线路上行道岔表
    /// </summary>
    public class LineTypeUpInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        [MaxLength(4)]
        [Required]
        public int LineTypeID { get; set; }

        /// <summary>
        /// 线路ID
        /// </summary>
        [MaxLength(4)]
        [Required]
        public int LineID { get; set; }

        public virtual LineInfo Line { get; set; }


        /// <summary>
        /// 上行站区ID
        /// </summary>
        [MaxLength(4)]
        public int StationID { get; set; }

        public virtual StationUpInfo StationUp { get; set; }

        /// <summary>
        /// 线路名称
        /// </summary>
        [MaxLength(128)]//最大长度
        public string LineName { get; set; }

        /// <summary>
        /// 站区名称
        /// </summary>
        [MaxLength(128)]//最大长度
        public string StationName { get; set; }

        /// <summary>
        /// 道岔类型
        /// </summary>
        [MaxLength(128)]//最大长度
        [Required]
        public string LineTypeName { get; set; }

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
    }
}
