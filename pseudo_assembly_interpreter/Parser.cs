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

            //string instruction = (from potential_command in consts.valid_commands
              //                where potential_command.Equals(lineFragments[0]) 
                //              select potential_command).FirstOrDefault();
            string instruction = consts.valid_commands.FirstOrDefault(potential_command => potential_command.Equals(lineFragments[0]));


            if (!string.IsNullOrEmpty(instruction)) { // checks if the instruction is equal to valid_commands (non conditional commands)
                return_command.instruction = lineFragments[0]; // adds instruction to command struct, no condition
                return_command.condition = "";
            }
            else { //removing potential condition from instruction and comparing again
                instruction = consts.valid_commands
                    .FirstOrDefault(potential_command => potential_command
                    .Equals(lineFragments[0].Substring(0, lineFragments[0].Length-2)));
                if (!string.IsNullOrEmpty(instruction)) {
                    return_command.instruction = lineFragments[0]; // adds instruction to command struct, no condition
                    return_command.condition = lineFragments[0].Substring(lineFragments[0].Length - 2);
                }
                else throw new ArgumentException("invalid or unimplemented command or condition");
            }




            if (lineFragments.Count == 2) {
                return_command.
            }
            return_command.receiver = Int32.Parse(lineFragments[1].Substring(1)); // adds reciever, an operand that is always present, to the struct
            if(lineFragments.Count == 4) { 
                // if 
                return_command.middle = Int32.Parse(lineFragments[2].Substring(1));
            }
            else {
                if(lineFragments[2].Substring(0,1).Equals('#')) {
                    string s = Convert.ToString(Int32.Parse(lineFragments[2].Substring(1)), 2);
                    s = s.PadLeft(32, '0');

                    return_command.sender_value = ;
                }
                else {

                }
            }
            
            return_command.
            return return_command;
        }

        public static string MARKER_LINE = "MARKER_LINE";
        public static string NO_MARKER = "NO_MARKER";
    }
}
