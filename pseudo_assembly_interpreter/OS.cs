using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace pseudo_assembly_interpreter.CPU {
    public class OS {
        CU cu;
        RegisterMemory registerMemory;
        public OS (CU cu, RegisterMemory regMem) {
            this.cu = cu;
            this.registerMemory = regMem;
        }

        public (List<Command>, Dictionary<string, int>) preprocess_program(List<string> codeLines) {

            Dictionary<string, int> markers = new Dictionary<string, int>();

            List<Command> commands = new List<Command>();

            int lineN = 0;

            List<string> temp = new List<string>();

            for (int i = 0; i < codeLines.Count; i++) {
                string line = codeLines[i];

                MatchCollection matches = Regex.Matches(line, "[^\\s\\,\t]+");
                // creating a regex match of words in between spaces and commas

                //operands.Add(new List<string>()); 

                // collect all the found words into a list of operands
                foreach (Match match in matches) {
                    temp.Add(match.Value);
                } // todo: operands

                //Parser.remove_surrounding_spaces(line); 
                string marker_check = Parser.get_marker(temp[0]);

                if (marker_check != Parser.NO_MARKER) {

                    markers.Add(marker_check, lineN);
                }
                else {
                    commands.Add(Parser.get_command(temp));
                    lineN++;
                }

            }

            //tuple
            return (commands, markers);
        }

        public void process_program(List<string> codeLines) {
            (var commands, var markers) = preprocess_program(codeLines);

            
            for (int i = 0; i < commands.Count;) {

                i = execute_command(commands[i], markers, i);

            }

        }
    }
}
