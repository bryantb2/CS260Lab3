using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StudentClasses;

namespace UnitTesting
{
    [TestFixture]
    class StudentTest
    {
        Student student1;
        Student student2;

        [SetUp]
        public void Setup()
        {
            //Student Objects
            student1 = new Student();
            student2 = new Student("Bob", 38);
        }

        [Test]
        public void BasicTest()
        {
            Assert.AreEqual(true, true);
        }

        [Test]
        public void NamePropertyClass()
        {
            //also a test of the constructors
            Assert.AreEqual("", student1.Name);
            Assert.AreEqual("Richard", student1.Name = "Richard");
            Assert.AreEqual("Bob", student2.Name);
            Assert.AreEqual("Bob Rong", student2.Name = "Bob Rong");
        }

        [Test]
        public void AgePropertyClass()
        {
            //also a test of the constructors
            Assert.AreEqual(0, student1.Age);
            Assert.AreEqual(44, student1.Age = 44);
            Assert.AreEqual(38, student2.Age);
            Assert.AreEqual(25, student2.Age = 25);
        }
    }
}
