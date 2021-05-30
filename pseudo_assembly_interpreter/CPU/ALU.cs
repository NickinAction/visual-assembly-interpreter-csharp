using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace pseudo_assembly_interpreter.CPU {
    public class ALU {
        RegisterMemory registerMemory;
        public ALU (RegisterMemory registerMemory) {
            this.registerMemory = registerMemory;
        }

        public void add(int reciever, int middle, int sender) {
            int carry = 0, sum, value;
            for (int i = 0; i < RegisterMemory.REGISTER_SIZE; i++) {
                sum = registerMemory.getBit(middle, i) + registerMemory.getBit(sender, i) + carry;
                value = sum % 2;
                carry = sum / 2;


                registerMemory.setBit(reciever, i, value);
            }
            bool overflow = (carry == 1); 
        }

        public void inc(int reciever) {
            int carry = 1, sum, value;

            for (int i = 0; i < RegisterMemory.REGISTER_SIZE; i++) {
                sum = registerMemory.getBit(reciever, i) + carry;
                value = sum % 2;
                carry = sum / 2;


                registerMemory.setBit(reciever, i, value);
            }

            bool overflow = (carry == 0);
            if(!registerMemory.CPSR_V) registerMemory.CPSR_V = overflow;

        }

        public void sub(int reciever, int middle, int sender) {
            int carry = 0, sum, value;
            for (int i = 0; i < RegisterMemory.REGISTER_SIZE; i++) {
                sum = registerMemory.getBit(middle, i) + 1 - registerMemory.getBit(sender, i) + carry;
                value = sum % 2;
                carry = sum / 2;


                registerMemory.setBit(reciever, i, value);
            }
            bool overflow = (carry == 0);
            registerMemory.CPSR_V = overflow;
            inc(reciever);
        }
        public void mov(int reciever, int middle, int sender) {
            for (int i = 0; i < RegisterMemory.REGISTER_SIZE; i++) {
                registerMemory.setBit(reciever, i, registerMemory.getBit(sender, i));
            }
        }
        public void cmp (int reciever, int middle, int sender) {
            sub(registerMemory.accumulator, middle, sender);
        }
    }

    
}
