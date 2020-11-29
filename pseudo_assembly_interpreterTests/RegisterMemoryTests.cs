using Microsoft.VisualStudio.TestTools.UnitTesting;
using pseudo_assembly_interpreter;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pseudo_assembly_interpreter.Tests
{
    [TestClass()]
    public class RegisterMemoryTests
    {
        RegisterMemory registerMemory;

        [TestInitialize]
        public void TestInitialize()
        {
            registerMemory = new RegisterMemory();
        }

        [TestMethod()]
        public void getRegisterTest()
        {
            int x = RegisterMemory.REGISTER_SIZE;

            BitArray testArray = new BitArray(x, false);
            testArray[1] = true;

            registerMemory.setRegister(1, testArray);

            Assert.IsTrue(registerMemory.getRegister(1).Equals(testArray));
        }
    }
}