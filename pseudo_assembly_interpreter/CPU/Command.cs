using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace pseudo_assembly_interpreter.CPU {
    /// <summary>Struct <c>Command</c> is used to send a processor instruction
    /// for <c>OS</c> to <c>Processor</c>. Reduntant variables assume default values when not used.
    /// <example> Command(string instruction) </example></summary>
    /// 
    public struct Command {
        public string instruction;
        public int receiver, middle, sender_reg;
        public string marker;
        public BitArray sender_value;
        public string condition;
        public char type;
       


        public Command(string instruction, string condition, int receiver, int middle, int sender_reg, string marker, BitArray sender_value) {
            this.instruction = instruction;
            this.condition = condition;
            this.receiver = receiver;
            this.middle = middle;
            this.sender_reg = sender_reg;
            this.marker = marker;
            this.sender_value = sender_value;
            this.type = 'n';
        }

        public Command (string instruction, string condition, string marker) {
            this.instruction = instruction;
            this.condition = condition;
            this.receiver = Parser.NO_REGISTER;
            this.middle = Parser.NO_REGISTER;
            this.sender_reg = Parser.NO_REGISTER;
            this.marker = marker;
            this.sender_value = null;
            this.type = 'b';
        }
    }
}