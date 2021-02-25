using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DH.Inspection.Line
{
    public class LineInfo : Entity<int>
    {
        /// <summary>
        /// 线路ID
        /// </summary>
        [Key]//主键表示
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]//设置为主键索引
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//设置为索引
        [Column("LineID")]//把主键字段重新自定义
        [MaxLength(4)]
        [Required]
        public override int Id { get; set; }

        /// <summary>
        /// 线路名称
        /// </summary>
        [MaxLength(128)]//最大长度
        [Required]//必须填字段
        public string LineName { get; set; }

    }
}
