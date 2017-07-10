using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvanceFileSystem.Models
{
    [Table("Positions")]
    public class Position : Model
    {
        [Key]
        public int Id { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        [Required]
        public bool status { get; set; }

        public virtual File File { get; set; }
    }
}
