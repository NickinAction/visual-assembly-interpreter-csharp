using Microsoft.VisualStudio.TestTools.UnitTesting;
using pseudo_assembly_interpreter;
using System;
using System.Collections.Generic;
using System.Collections;
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

        [TestMethod()]
        public void get_commandTest() {

            List<string> lineFragments1 = new List<string> { "bne", "marker" };
            List<string> lineFragments2 = new List<string> { "movne", "r1", "#3" };
            List<string> lineFragments3 = new List<string> { "mov", "r2", "r1" };
            List<string> lineFragments4 = new List<string> { "addeq", "r1", "r2", "#3" };
            List<string> lineFragments5 = new List<string> { "add", "r1", "r2", "r3" };
            List<string> lineFragments6 = new List<string> { "add", "r1", "r2" };

            BitArray binarynum3 = new BitArray(RegisterMemory.REGISTER_SIZE);
            binarynum3[0] = true;
            binarynum3[1] = true;

            Command command1 = new Command("b", "ne", "marker");
            Command command2 = new Command("mov", "ne", 1, 1, Parser.NO_REGISTER, "", binarynum3);
            Command command3 = new Command("mov", "", 2, 2, 1, "", null);
            Command command4 = new Command("add", "eq", 1, 1, Parser.NO_REGISTER, "", binarynum3);
            Command command5 = new Command("add", "", 1, 2, 3, "", null);
            Command command6 = new Command("add", "", 1, 1, 2, "", null);

            //Console.WriteLine(String.Join(" ", lineFragments2));
            Console.WriteLine("Assert #1: ");
            Assert.IsTrue(commandCompare(Parser.get_command(lineFragments1), command1));
            Console.WriteLine("Assert #2: ");
            Assert.IsTrue(commandCompare(Parser.get_command(lineFragments2), command2));
            Console.WriteLine("Assert #3: ");
            Assert.IsTrue(commandCompare(Parser.get_command(lineFragments3), command3));
            Console.WriteLine("Assert #4: ");
            Assert.IsTrue(commandCompare(Parser.get_command(lineFragments4), command4));
            Console.WriteLine("Assert #4: ");
            Assert.IsTrue(commandCompare(Parser.get_command(lineFragments5), command5));
            Console.WriteLine("Assert #4: ");
            Assert.IsTrue(commandCompare(Parser.get_command(lineFragments6), command6));

        }

        public bool commandCompare(Command actual, Command expected) {
            if (actual.instruction    != expected.instruction ||
                    actual.condition  != expected.condition ||
                    actual.marker     != expected.marker ||
                    actual.sender_reg != expected.sender_reg ||
                    actual.middle     != expected.middle ||
                    actual.receiver   != expected.receiver) {
                Console.WriteLine(actual.instruction + " : " + expected.instruction);
                Console.WriteLine(actual.condition + " : " + expected.condition);
                Console.WriteLine("|" + actual.marker + "| : |" + expected.marker + "|");
                Console.WriteLine(actual.receiver + " : " + expected.receiver);
                Console.WriteLine(actual.middle + " : " + expected.middle);
                Console.WriteLine(actual.sender_reg + " : " + expected.sender_reg);
                return false;
            }

            if (expected.sender_value == null && actual.sender_value == null) {
                return true;
            }

            bool equals = actual.sender_value.Xor(expected.sender_value).OfType<bool>().All(e => !e);

            return equals;
        }
    }
}