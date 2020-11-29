using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pseudo_assembly_interpreter
{
    public class RegisterMemory
    {
        public RegisterMemory()
        {
            CPSR = new BitArray(REGISTER_SIZE, false);

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
        private BitArray CPSR;
        const int N_REGISTERS = 16;
        public const int REGISTER_SIZE = 32;
    }
}
