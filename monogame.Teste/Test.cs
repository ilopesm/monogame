using NUnit.Framework;
using System;

namespace monogame.Teste
{
    public class Test
    {
        private Tester tester;

        [SetUp()]
        public void TestSetup()
        {
            tester = new Tester();
        }

        [Test()]
        public void TestCase()
        {
            Console.WriteLine("Hello World!");
            Assert.That(true, Is.EqualTo(tester.isBool()));
        }
    }
}