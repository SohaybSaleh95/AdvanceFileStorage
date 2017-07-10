using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvanceFileSystem.Models
{
    [Table("EditLogs")]
    public class EditLog : Model
    {
        public int UserId { get; set; }

        public int FileId { get; set; }

        public File OldFile { get; set; }
        public File NewFile { get; set; }

        public string OldData { get; set; }

        
        public string NewData { get; set; }

        public DateTime Time { get; set; } = DateTime.Now;

        [Required]
        [RegularExpression("^[0-9a-zA-Z]{2}:[0-9a-zA-Z]{2}:[0-9a-zA-Z]{2}:[0-9a-zA-Z]{2}:[0-9a-zA-Z]{2}:[0-9a-zA-Z]{2}$")]
        public string MacAddress { get; set; }
    }
}
