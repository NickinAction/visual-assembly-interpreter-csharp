using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pseudo_assembly_interpreter {
    class VM {
        OS os;
        public VM () {
            CU cu = new CU();
            // ALU
            os = new OS(cu);
        }

        void run_program(List<string> codelines) {
            os.process_program(codeLines);
        }


    }
}
