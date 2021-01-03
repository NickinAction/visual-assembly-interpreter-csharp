using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pseudo_assembly_interpreter
{
    static class consts {

        static public List<string> valid_commands = new List<string> { "add" , "mov", "sub", "b"};
        static public List<string> valid_conditions = new List<string> { "eq" , "ne"};
        static public List<char> number_indicators = new List<char> { '#', 'b', 'x' };
    }
}
