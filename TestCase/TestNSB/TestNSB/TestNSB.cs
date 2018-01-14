using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestNSB
{
    [TestFixture]
    public class TestNSB
    {
        [Test]
        public void Test1()
        {
            using (var el = new El())
            {
                el.TestCase1();
                Thread.Sleep(5000);
            }
        }

        [Test]
        public void Test2()
        {
            using (var el = new El())
            {
                el.TestCase2();
                Thread.Sleep(5000);
            }
        }

        [Test]
        public void Test3()
        {
            using (var el = new El())
            {
                el.TestCase3();
                Thread.Sleep(5000);
            }
        }

        [Test]
        public void Test4()
        {
            using (var el = new El())
            {
                el.TestCase4();
                Thread.Sleep(5000);
            }
        }

        [Test]
        public void Test5()
        {
            using (var el = new El())
            {
                el.TestCase5();
                Thread.Sleep(5000);
            }
        }

        [Test]
        public void Test6()
        {
            using (var el = new El())
            {
                el.TestCase6();
                Thread.Sleep(5000);
            }
        }

        [Test]
        public void Test7()
        {
            using (var el = new El())
            {
                el.TestCase7();
                Thread.Sleep(5000);
            }
        }

        [Test]
        public void Test8()
        {
            using (var el = new El())
            {
                el.TestCase8();
                Thread.Sleep(10000);
            }
        }

        [Test]
        public void Test9()
        {
            using (var el = new El())
            {
                el.TestCase9();
                Thread.Sleep(5000);
            }
        }

        [Test]
        public void Test10()
        {
            using (var el = new El())
            {
                el.TestCase10();
                Thread.Sleep(5000);
            }
        }

    }
}
