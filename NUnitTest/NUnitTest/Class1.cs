using System;
using NUnit.Framework;


namespace NUnitTest
{
    [TestFixture]
    public class Class1
    {
        public int s = 0;

        [Test]
        [SetUp]
        public void Setup()
        {

            
            int x = 10;
            int y = 20;

            s = x + y;

        }

        [Test]
        public void Test1()
        {
            //Codigo prueba
            int p = s - 10;

            Assert.AreEqual(p, 20);

        }

        [Test]
        public void Test2()
        {
            //Codigo prueba

            int p = s + 10;

            Assert.AreEqual(p, 20);

        }


        [Test]
        [TearDown]
        public void Final()
        {
            //Codigo prueba

            int x = 10;
            int y = 2;

            int result = x * y;

            Assert.AreEqual(result, 20);

        }

    }
}
