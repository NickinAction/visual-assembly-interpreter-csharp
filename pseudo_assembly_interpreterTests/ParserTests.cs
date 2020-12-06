using Microsoft.VisualStudio.TestTools.UnitTesting;
using pseudo_assembly_interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pseudo_assembly_interpreter.Tests {
    [TestClass()]
    public class ParserTests {
        [TestMethod()]
        public void remove_surrounding_spacesTest() {
            string[] codeLines = { " f fdfdfdfd fd       ", "fdfdf     ", "     fdfdfdf" };

            Assert.AreEqual("f fdfdfdfd fd", Parser.remove_surrounding_spaces(codeLines[0]));
            Assert.AreEqual("fdfdf", Parser.remove_surrounding_spaces(codeLines[1]));
            Assert.AreEqual("fdfdfdf", Parser.remove_surrounding_spaces(codeLines[2]));
        }
    }
}