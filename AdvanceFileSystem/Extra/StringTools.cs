using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceFileSystem.Extra
{
    public class StringTools
    {

        public static bool AnyEmpty(params string[] vars)
        {
            foreach (string s in vars)
            {
                if (s == "")
                    return true;
            }
            return false;
        }

    }
}
