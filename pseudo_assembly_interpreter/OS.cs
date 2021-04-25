using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace pseudo_assembly_interpreter {
    public class OS {
        public OS () {

        }

        public List<List<string>> preprocess_program(List<string> codeLines) {

            Dictionary<string, int> markers = new Dictionary<string, int>();

            List<List<string>> operands = new List<List<string>>();

            for (int i = 0; i < codeLines.Count; i++) {
                string line = codeLines[i];

                MatchCollection matches = Regex.Matches(line, "[^\\s\\,\t]+");
                // creating a regex match of words in between spaces and commas

                operands.Add(new List<string>());

                // collect all the found words into a list of operands
                foreach (Match match in matches) {
                    operands[i].Add(match.Value);
                } // todo: operands

                //Parser.remove_surrounding_spaces(line); 
                string marker_check = Parser.collect_marker(operands[i][0]);
                if (marker_check != Parser.NO_MARKER) {
                    markers.Add(marker_check, i);
                }

            }

            return operands;
        }

        public void process_program(List<string> codeLines) {
            var lineFragments = preprocess_program(codeLines);

            for (int i = 0; i < codeLines.Count; i++) {
                if (codeLines[i] == Parser.MARKER_LINE) continue;
                Command temp = Parser.get_command(lineFragments[i]);

            }
            for (int i = 0; i < codeLines.Count; i++) {
                if (codeLines[i] == Parser.MARKER_LINE) continue;

                //process_command(operands[i]) ... TODO

            }

        }
    }
}
