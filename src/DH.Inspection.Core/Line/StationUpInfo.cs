using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DH.Inspection.Line
{
    /// <summary>
    /// 站区上行表
    /// </summary>
    public class StationUpInfo
    {
        /// <summary>
        /// 站区编号
        /// </summary>
        [MaxLength(4)]
        [Required]
        public int StationID { get; set; }

        /// <summary>
        /// 线路id
        /// </summary>
        [MaxLength(4)]
        [Required]
        public int LineID { get; set; }

        public virtual LineInfo LineInfo { get; set; }

        /// <summary>
        /// 站区名称
        /// </summary>
        [MaxLength(128)]//最大长度
        [Required]//必须填字段
        public string StationName { get; set; }

        /// <summary>
        /// 起始千米
        /// </summary>
        [MaxLength(4)]
        [Required]
        public int StationKM { get; set; }

        /// <summary>
        /// 起始米
        /// </summary>
        [MaxLength(4)]
        [Required]
        public int StationM { get; set; }
        /// <summary>
        /// 结束千米
        /// </summary>
        [MaxLength(4)]
        [Required]
        public int EndKM { get; set; }

        /// <summary>
        /// 结束米
        /// </summary>
        [MaxLength(4)]
        [Required]
        public int EndM { get; set; }
    }
}
