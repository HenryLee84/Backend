using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    [Table("user")]
    public class User
    {
        /// <summary>
        /// 流水號
        /// </summary>
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// 使用者名稱
        /// </summary>
        [StringLength(50)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 帳號
        /// </summary>
        [StringLength(50)]
        [Column("account")]
        public string Account { get; set; } = string.Empty;

        /// <summary>
        /// 密碼
        /// </summary>
        [StringLength(200)]
        [Column("password")]
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// 密碼
        /// </summary>
        [Column("create_time")]
        public long CreateTime { get; set; }
    }
}
