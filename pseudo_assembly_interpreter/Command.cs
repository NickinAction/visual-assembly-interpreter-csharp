using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace pseudo_assembly_interpreter {
    public struct Command {
        public string instruction;
        public int receiver, middle, sender_reg;
        public string marker;
        public BitArray sender_value;
        public Command(string instruction, int receiver, int middle, int sender_reg, string marker, BitArray sender_value) {
            this.instruction = instruction;
            this.receiver = receiver;
            this.middle = middle;
            this.sender_reg = sender_reg;
            this.marker = marker;
            this.sender_value = sender_value;
        }
    }
}
