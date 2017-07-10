using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvanceFileSystem.Models
{
    [Table("Citizens")]
    public class Citizen : Model
    {
        [Key]
        [Range(100000000,999999999)]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [ForeignKey("Address")]
        public short AddressId { get; set; }
        public virtual Address Address { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string PoBox { get; set; }
    }
}
