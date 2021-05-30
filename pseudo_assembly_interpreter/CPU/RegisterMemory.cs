using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pseudo_assembly_interpreter.CPU {
    public class RegisterMemory
    {
        public RegisterMemory()
        {
            CPSR = new BitArray(REGISTER_SIZE, false);
            //Accumulator = new BitArray(REGISTER_SIZE, false);

                registers = new List<BitArray>();

            for (int i = 0; i < N_REGISTERS; i++) {
                registers.Add(new BitArray(REGISTER_SIZE, false));
            }
        }

        public int getBit(int reg_index, int pos) {
            return registers[reg_index][pos]? 1 : 0;
        }

        public void setBit(int reg_index, int pos, int value) {
            registers[reg_index][pos] = (value == 1);
        }

        public BitArray getRegister (int index) {
            return registers[index];
        }

        public void setRegister(int index, BitArray value){
            registers[index] = value;
        }

        public List<BitArray> registers;
        const int N_REGISTERS = 16;
        public BitArray CPSR;
        public int accumulator = 12;
        public const int REGISTER_SIZE = 32;

        public bool CPSR_N { 
            get => CPSR[REGISTER_SIZE - 1];
            set { CPSR[REGISTER_SIZE - 1] = value;}
        }
        public bool CPSR_Z {
            get => CPSR[REGISTER_SIZE - 2];
            set { CPSR[REGISTER_SIZE - 2] = value; }
        }
        public bool CPSR_C {
            get => CPSR[REGISTER_SIZE - 3];
            set { CPSR[REGISTER_SIZE - 3] = value; }
        }
        public bool CPSR_V {
            get => CPSR[REGISTER_SIZE - 4];
            set { CPSR[REGISTER_SIZE - 4] = value; }
        }

    }
}
