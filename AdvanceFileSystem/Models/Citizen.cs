using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace AdvanceFileSystem.Models
{
    [Table("Citizens")]
    public class Citizen : Model
    {
        [Key]
        [Range(100000000,999999999,ErrorMessage = "Card id must be 9 numbers exactly")]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [ForeignKey("Address")]
        [Browsable(false)]
        public short AddressId { get; set; }
        public virtual Address Address { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string PoBox { get; set; }

        public Citizen()
        {

        }

        public Citizen(string name,string id,DateTime birthdate,short address,string street,string pobox)
        {
            this.FullName = name;
            int Id;
            int.TryParse(id, out Id);
            this.Id = Id;
            BirthDate = birthdate;
            AddressId = address;
            Street = street;
            PoBox = pobox;
        }

    }
}
