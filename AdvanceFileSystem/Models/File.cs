using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvanceFileSystem.Models
{
    [Table("Files")]
    public class File : Model
    {

        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Desc { get; set; }

        [Required]
        [ForeignKey("Category")]
        public short CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public DateTime AddedTime { get; set; }

        [Required]
        [ForeignKey("Position")]
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }

        [Required]
        [Range(1,100)]
        public byte SeePermission { get; set; }

        [Required]
        [Range(1,100)]
        public byte GetPermission { get; set; }
    }
}
