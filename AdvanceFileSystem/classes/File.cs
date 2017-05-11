using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceFileSystem.classes
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public string Desc { get; set; }
        public List<Citizen> Participants { get; set; }
        public string AddedTime { get; set; }
        public User User { get; set; }
    }
}
