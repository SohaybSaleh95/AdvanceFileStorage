using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvanceFileSystem.Models
{
    [Table("Categories")]
    public class Category : Model
    {
        [Key]
        public short Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<File> Files { get; set; }
    }
}
