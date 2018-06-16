using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameEngine.Tests
{
    [TestClass]
    public class Lifecycle
    {
         static string _someTestContext;

        [TestInitialize]
        public void LifecycleInit()
        {
            Console.WriteLine("    TestInitialize Lifecycle");
        }

        [TestCleanup]
        public void LifecycleClean()
        {
            Console.WriteLine("    TestCleanup Lifecycle");
        }


        [ClassInitialize]
        public static void LifecycleClassInit(TestContext context)
        {
            Console.WriteLine("    ClassInitialize Lifecycle");
            Console.WriteLine("    Data loaded from disk or some experience object creation");
            _someTestContext = "42";
        }



        [TestMethod]
        public void TestA()
        {
            Console.WriteLine($"    Test A starting {_someTestContext}");
        }

        [TestMethod]
        public void TestB()
        {
            Console.WriteLine($"    Test B starting {_someTestContext}");
        }
    }
}
