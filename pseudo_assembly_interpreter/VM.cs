using pseudo_assembly_interpreter.CPU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pseudo_assembly_interpreter {
    public class VM {
        OS os;
        RegisterMemory registerMemory;
        public VM () {
            ALU alu = new ALU(registerMemory);
            CU cu = new CU(registerMemory, alu);
            registerMemory = new RegisterMemory();
            os = new OS(cu, registerMemory);
        }

        public void run_program(List<string> codelines) {
            os.process_program(codelines);
        }


    }
}
