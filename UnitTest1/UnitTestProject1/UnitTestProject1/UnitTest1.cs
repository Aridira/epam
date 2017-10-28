using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
        [TestMethod]
        public void additionTest1()
        {
            Assert.AreEqual(100.0, Calculator.addition(50.0, 50.0));

        }
        [TestMethod]
        public void additionTest2()
        {
            Assert.AreEqual(0.0, Calculator.addition(-50.0, 50.0));

        }
        [TestMethod]
        public void additionTest3()
        {
            Assert.AreEqual(-100.0, Calculator.addition(-50.0, -50.0));

        }

        [TestMethod]
        public void additionTest4()
        {
            Assert.AreEqual(50.0, Calculator.addition(50.0, 0.0));

        }

        [TestMethod]
        public void additionTest5()
        {
            Assert.AreEqual(0.0, Calculator.addition(0.0, 0.0));

        }


        
        [TestMethod]
        public void substractionTest1()
       
        {
            Assert.AreEqual(0.0, Calculator.substraction(50.0, 50.0));

        }
        [TestMethod]
        public void substractionTest2()
        {
            Assert.AreEqual(-100.0, Calculator.substraction(-50.0, 50.0));

        }
        [TestMethod]
        public void substractionTest3()
        {
            Assert.AreEqual(0.0, Calculator.substraction(-50.0, -50.0));

        }

       
        [TestMethod]
        public void substractionTest4()
        {
            Assert.AreEqual(50.0, Calculator.substraction(50.0, 0.0));

        }

        [TestMethod]
        public void substractionTest5()
        {
            Assert.AreEqual(0.0, Calculator.substraction(0.0, 0.0));

        }
        


        [TestMethod]
        public void multiplicationTest1()
        
        {
            Assert.AreEqual(4.0, Calculator.multiplication(2.0, 2.0));

        }
        [TestMethod]
        public void multiplicationTest2()
        {
            Assert.AreEqual(-4.0, Calculator.multiplication(-2.0, 2.0));

        }
        [TestMethod]
        public void multiplicationTest3()
        {
            Assert.AreEqual(4.0, Calculator.multiplication(-2.0, -2.0));

        }

        [TestMethod]
        public void multiplicationTest4()
        {
            Assert.AreEqual(0.0, Calculator.multiplication(2.0, 0.0));

        }

        [TestMethod]
        public void multiplicationTest5()
        {
            Assert.AreEqual(0.0, Calculator.multiplication(0.0, 0.0));

        }
        

        [TestMethod]
        public void divisionTest1()
        
        {
            Assert.AreEqual(1.0, Calculator.division(2.0, 2.0));

        }
        [TestMethod]
        public void divisionTest2()
        {
            Assert.AreEqual(-1.0, Calculator.division(-2.0, 2.0));

        }
        [TestMethod]
        public void divisionTest3()
        {
            Assert.AreEqual(1.0, Calculator.division(-5.0, -5.0));

        }

        [TestMethod]
        public void divisionTest4()
        {
            Assert.IsNotNull(Calculator.division(5.0, 0.0));

        }
        [TestMethod]
        public void divisionTest5()
        {
            Assert.IsNull(Calculator.division(0.0, 0.0));

        }
    }
}
