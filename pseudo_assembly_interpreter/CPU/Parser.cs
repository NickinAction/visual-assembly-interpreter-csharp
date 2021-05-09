using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Collections;

namespace pseudo_assembly_interpreter {
    public class Parser {


        
        public static string remove_surrounding_spaces(string line) {
            // (^\\s+|\\s+$)
            string temp = Regex.Replace(line, "(^\\s+|\\s+$)", "");
            return temp;
        }
        public static string get_marker (string line) {
            if (line.Last() == ':') {
                string temp = line.Substring(0, line.Length - 1);
                line = MARKER_LINE;
                return temp;
            }
            else return NO_MARKER;
        }

        public static int get_reg_num (string reg) {
            return Int32.Parse(reg.Substring(1));
        }

        public static BitArray val_to_bitarray (string str) {
            string s = Convert.ToString(Int32.Parse(str.Substring(1)), 2); //converting dec string to binary in and then back to string 

            char[] charArray = s.PadLeft(32, '0').ToCharArray(); //padding zeroes to make string length be 32 
            Array.Reverse(charArray);
            s = new String(charArray);
            var temp = new BitArray(s.Select(c => c == '1').ToArray());
            return temp;
        }

        /// <summary>
        /// Builds a <c>Command</c> from a <c>List&lt;string&gt;</c> of line fragments the user command consists of.
        /// </summary>
        /// <param name="lineFragments"></param>
        /// <returns></returns>
        public static Command get_command(List<string> lineFragments) {
            if (lineFragments.Count == 0) {
                throw new ArgumentException("line frangments number can't be zero");
            }

            Command return_command = new Command();
            // Initialises an empty Command to be filled later.

            string instruction = consts.valid_commands
                .FirstOrDefault(potential_command => potential_command
                .Equals(lineFragments[0]));


            if (!string.IsNullOrEmpty(instruction)) { // checks if the instruction is equal to valid_commands (non conditional commands)
                return_command.instruction = lineFragments[0]; // adds instruction to command struct, no condition
                return_command.condition = "";
            }
            else { //removing potential condition from instruction and comparing again
                int instruction_condition_cutoff = lineFragments[0].Length - 2;
                instruction = consts.valid_commands
                    .FirstOrDefault(potential_command => potential_command
                    .Equals(lineFragments[0].Substring(0, instruction_condition_cutoff)));

                if (!string.IsNullOrEmpty(instruction)) {
                    return_command.instruction = instruction; // adds instruction to command struct, no condition
                    return_command.condition = lineFragments[0].Substring(instruction_condition_cutoff);
                }
                else throw new ArgumentException("invalid or unimplemented command or condition");
            }



            if(return_command.instruction.Equals("b")) { // if instruction is branch (b), returning marker 
                return_command = new Command("b", return_command.condition, lineFragments[1]);
            }
            else {
                //adding reciever as integer (removing the r)

                return_command.receiver = get_reg_num(lineFragments[1]);
                return_command.marker = NO_MARKER;

                // Determining whether there is a middle operand in the input

                // will shift future references to lineFragments in case there is a middle operand,
                int index_shifter = 0; //used to avoid similar if statements
                if (lineFragments.Count == 4) { //middle is denoted explicitly 
                    return_command.middle = get_reg_num(lineFragments[2]);
                    index_shifter = 1;
                } 
                else {
                    return_command.middle = return_command.receiver;
                }
                
                //figure out sender

                char number_indicator = consts.number_indicators
                    .FirstOrDefault(potential_num_indicator => potential_num_indicator
                    .Equals(lineFragments[2 + index_shifter].Substring(0, 1)));

                Console.WriteLine(number_indicator);

                if (number_indicator == '\0') { //default char value
                    // sender is a value
                    return_command.sender_value = val_to_bitarray(lineFragments[2 + index_shifter]);
                    return_command.sender_reg = NO_REGISTER;
                    Console.WriteLine("value");
                }
                else {
                    //sender is a register
                    return_command.sender_reg = get_reg_num(lineFragments[2 + index_shifter]);
                    return_command.sender_value = null;
                    Console.WriteLine("register");
                }

            }

            return return_command;
        }

        public static string MARKER_LINE = "MARKER_LINE";
        public static string NO_MARKER = "";
        public static int NO_REGISTER = -1;
    }
}
