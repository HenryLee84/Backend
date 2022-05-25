using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    [Table("parameter")]
    public class Parameter
    {
        /// <summary>
        /// 代號
        /// </summary>
        [StringLength(30)]
        [Column("code")]
        [Key]
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 值
        /// </summary>
        [StringLength(300)]
        [Column("value")]
        public string Value { get; set; } = string.Empty;
    }
}
