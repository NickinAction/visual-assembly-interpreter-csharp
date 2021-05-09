using pseudo_assembly_interpreter.CPU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace pseudo_assembly_interpreter.CPU {
    public class CU {

        RegisterMemory registerMemory;
        ALU alu;

        public CU (RegisterMemory registerMemory, ALU alu) {
            this.registerMemory = registerMemory;
            this.alu = alu;
        }

        int execute_command(Command command, Dictionary<string, int> markers, int i) {

            if (!check_condition(command.condition)) {
                return i + 1; // skip command
            }

            if (command.type == 'b') {
                return markers[command.marker]; // changing the next code line to marker 
            }

            send_to_ALU(command);
            return i + 1; // next command
        }

        void send_to_ALU(Command command) {

            MethodInfo method;

            try {
                method = alu.GetType().GetMethod(command.instruction);
            }
            catch (Exception e) {
                throw new ArgumentException("Something went wrong while passing the command to ALU");
            }
            if (method == null) {
                throw new ArgumentException("Command doesn't exist");
            }

            object[] parameters = new object[3];

            parameters[0] = command.receiver;
            parameters[1] = command.middle;

            if (command.sender_reg == Parser.NO_REGISTER) {
                //sender is a value
                registerMemory.setRegister(registerMemory.accumulator, command.sender_value);
                parameters[2] = registerMemory.accumulator;

            }
            else {
                parameters[2] = command.sender_reg;
            }

            method.Invoke(alu, parameters);
        }

        bool check_condition (string condition) {

            if (condition == "") return true;

            if (condition == "eq") {
                return registerMemory.CPSR_Z();
            }
            else if (condition == "ne") {
                return !registerMemory.CPSR_Z();
            }
            else {
                throw new NotImplementedException("condition not implemented");
            }

        }

    }



}

