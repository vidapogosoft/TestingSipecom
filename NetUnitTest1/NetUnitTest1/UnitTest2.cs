using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NetUnitTest1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Codigo de la prueba

            Assert.AreEqual(10, 5 + 5); //Correcto

        }

        [TestMethod]
        public void TestMethod2()
        {
            //Codigo de la prueba

            Assert.AreEqual(10, 1 + 5); //Error 

        }

        [TestMethod]
        public void TestMethod3()
        {
            //Codigo de la prueba

            Assert.AreNotSame(10, 10); //Error 

        }

        [TestMethod]
        public void TestMethod4()
        {
            //Codigo de la prueba

            Assert.AreSame(10, 10); //Error 

        }

        [TestMethod]
        public void TestMethod5()
        {
            //Codigo de la prueba

            CollectionAssert.AreEqual(new[] { 1, 2}, new[] { 1, 2 }); //Correcto

        }

        [TestMethod]
        public void TestMethod6()
        {
            //Codigo de la prueba

            CollectionAssert.AreEqual(new[] { 1, 2 }, new[] { 1, 2, 3 }); //Error

        }

        [TestMethod]
        public void TestMethod7()
        {
            //Codigo de la prueba

            if (DateTime.Now.Hour != 10)
                Assert.Inconclusive("No va a terminar el test");

        }

    }
}
