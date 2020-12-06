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

        public static string MARKER_LINE = "MARKER_LINE";
        public static string NO_MARKER = "NO_MARKER";
    }
}
