using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvanceFileSystem.Models
{
    [Table("Participants")]
    public class Participant : Model
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("File")]
        public int FileId { get; set; }
        public virtual File File { get; set; }

        [Key]
        [Column(Order = 2)]
        [Range(100000000, 999999999)]
        [ForeignKey("Citizen")]
        public int CitizenId { get; set; }
        public virtual Citizen Citizen { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
