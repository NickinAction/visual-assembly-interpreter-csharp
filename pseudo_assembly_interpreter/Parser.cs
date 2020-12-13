using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace pseudo_assembly_interpreter {
    public class Parser {

        public static string remove_surrounding_spaces(string line) {
            // (^\\s+|\\s+$)
            string temp = Regex.Replace(line, "(^\\s+|\\s+$)", "");
            return temp;
        }
        public static string collect_marker (string line) {
            if (line.Last() == ':') {
                string temp = line.Substring(0, line.Length - 1);
                line = MARKER_LINE;
                return temp;
            }
            else return NO_MARKER;
        }

        public static Command get_command(List<string> lineFragments) {
            if (lineFragments.Count == 0) {
                throw new ArgumentException("line frangments number can't be zero");
            }

            Command return_command = new Command();
            return_command.instruction = lineFragments[0];
            return_command.receiver = Int32.Parse(lineFragments[1].Substring(1));
            if(lineFragments.Count == 4) {
                return_command.middle = Int32.Parse(lineFragments[2].Substring(1));
            }
            else {
                if(lineFragments[2].Substring(0,1).Equals('#')) {
                    string s = Convert.ToString(Int32.Parse(lineFragments[2].Substring(1)), 2);
                    s = s.PadLeft(32, '0');

                    return_command.sender_value = ;
                }
            }
            
            return_command.
            return return_command;
        }

        public static string MARKER_LINE = "MARKER_LINE";
        public static string NO_MARKER = "NO_MARKER";
    }
}
