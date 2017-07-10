using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvanceFileSystem.Models
{
    public class Model
    {
        [NotMapped]
        public bool IsValid
        {
            get
            {
                ValidationContext Context = new ValidationContext(this);
                return Validator.TryValidateObject(this, Context, Errors);
            }
        }

        [NotMapped]
        public List<ValidationResult> Errors { get; private set; } = new List<ValidationResult>();
		
		public string Error {
			get
			{
				return String.Join("\r\n",Errors.Select(e => e.ErrorMessage).ToArray());
			}
		}
    }
}
