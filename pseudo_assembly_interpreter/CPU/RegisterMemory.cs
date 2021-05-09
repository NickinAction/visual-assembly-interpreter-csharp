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

            for (int i = 0; i < N_REGISTERS; i++)
            {
                registers.Add(new BitArray(REGISTER_SIZE, false));
            }
        }

        public BitArray getRegister (int index)
        {
            return registers[index];
        }

        public void setRegister(int index, BitArray value)
        {
            registers[index] = value;
        }

        private List<BitArray> registers;
        const int N_REGISTERS = 16;
        public BitArray CPSR;
        public int accumulator = 0;
        public const int REGISTER_SIZE = 32;

        public bool CPSR_N() {
            return CPSR[REGISTER_SIZE - 1];
        }
        public bool CPSR_Z() {
            return CPSR[REGISTER_SIZE - 2];
        }
        public bool CPSR_C() {
            return CPSR[REGISTER_SIZE - 3];
        }
        public bool CPSR_V() {
            return CPSR[REGISTER_SIZE - 4];
        }
    }
}
