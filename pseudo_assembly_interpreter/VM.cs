using pseudo_assembly_interpreter.CPU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pseudo_assembly_interpreter {
    public class VM {
        OS os;
        RegisterMemory registerMemory;
        public VM () {
            registerMemory = new RegisterMemory();
            ALU alu = new ALU(registerMemory);
            CU cu = new CU(registerMemory, alu);
            os = new OS(cu, registerMemory);
        }

        public void run_program(List<string> codelines, System.Windows.Forms.Label[] register_labels) {
            os.process_program(codelines);

            byte[] temp;

            for (int i = 0; i < 16; i++) {
                temp = new byte[RegisterMemory.REGISTER_SIZE];
                registerMemory.getRegister(i).CopyTo(temp, 0);
                string full_reg = "";
                for (int j = 0; j < RegisterMemory.REGISTER_SIZE; j++) {
                    full_reg += registerMemory.getBit(i, j);
                }
                register_labels[i].Text = "R" + i + ": " + full_reg;
            }

        }


    }
}
