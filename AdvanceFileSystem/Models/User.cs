using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvanceFileSystem.Models
{
    [Table("Users")]
    public class User : Model
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        [Range(1, short.MaxValue)]
        [ForeignKey("Department")]
        public short DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Range(100000000,999999999)]
        public int CardId { get; set; }
        
        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [Range(1,short.MaxValue)]
        [ForeignKey("Address")]
        public short AddressId { get; set; }
        public virtual Address Address { get; set; }

        [Required]
        [Range(1,100)]
        public byte Permission { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }

        [Required]
        public bool Admin { get; set; }

        [Required]
        public bool Enabled { get; set; }

        public User()
        {
            CreateTime = DateTime.Now;
            Admin = false;
            Enabled = true;
        }

    }
}
