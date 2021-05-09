using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pseudo_assembly_interpreter {
    public class CU {
        int execute_command(Command command, Dictionary<string, int> markers, int i) {

            if (command.type == 'b') {
                return markers[command.marker];
            }

            if(check_condition(command.condition))


            return i += 1;

        }

        bool check_condition (string condition) {

            if (condition == "") return true;

            if (condition == "eq") {

            }
            else if (condition == "ne") {

            }

        }

    }



}

