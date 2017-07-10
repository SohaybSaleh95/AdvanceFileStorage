using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvanceFileSystem.Models
{
    [Table("RequestLogs")]
    class RequestLog : Model
    {
        [Required]
        [ForeignKey("File")]
        public int FileId { get; set; }
        public virtual File File { get; set; }

        public DateTime Time { get; set; } = DateTime.Now;

        [Required]
        public string ActionType { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [RegularExpression("^[0-9a-zA-Z]{2}:[0-9a-zA-Z]{2}:[0-9a-zA-Z]{2}:[0-9a-zA-Z]{2}:[0-9a-zA-Z]{2}:[0-9a-zA-Z]{2}$")]
        public string MacAddress { get; set; }

    }
}
