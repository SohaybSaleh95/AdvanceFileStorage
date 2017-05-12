using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceFileSystem.Extra
{
    public class Errors
    {
        public static String ConnectionError { get; } = "An error occured while connecting to the database";
        public static String FieldEmpty { get; } = "One or more fields are empty \n\r please fill all fields";
    }
}
