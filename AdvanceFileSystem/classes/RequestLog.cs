using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceFileSystem.classes
{
    public class RequestLog
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string EmpName { get; set; }
        public string RequestType { get; set; }
        public string RequestTime { get; set; }
    }
}
