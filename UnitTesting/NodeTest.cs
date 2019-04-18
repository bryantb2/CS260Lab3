using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedListCustom;
using NUnit.Framework;

namespace UnitTesting
{
    [TestFixture]
    public class NodeTest
    {
        Node<char> link1;
        Node<char> link2;
        Node<char> link3;
        Node<char> link = null;

        [SetUp]
        public void Setup()
        {
            link1 = new Node<char>('a', link2, null);
            link2 = new Node<char>('b', link3, link1);
            link3 = new Node<char>('c', null, link2);
        }

        [Test]
        public void BasicTest()
        {
            Assert.AreEqual(true, true);
        }

        [Test]
        public void ValueGetterSetterTest()
        {
            //Getters
            Assert.AreEqual('a', link1.Value);
            Assert.AreEqual('b', link2.Value);
            Assert.AreEqual('c', link3.Value);
            //Setters
            Assert.AreEqual('F', link2.Value= 'F');
            Assert.AreEqual('@', link1.Value = '@');
        }

        [Test]
        public void NextGetterSetterTest()
        {
            //setters
            Assert.AreEqual(link2, link1.Next = link2);
            Assert.AreEqual(link3, link2.Next = link3);
            //getters
            Assert.AreEqual(link2, link1.Next);
            Assert.AreEqual(link3, link2.Next);
        }

        [Test]
        public void PreviousGetterSetterTest()
        {
            //setters
            Assert.AreEqual(link1, link2.Previous = link1);
            Assert.AreEqual(link2, link3.Previous = link2);
            //getters
            Assert.AreEqual(null, link1.Previous);
            Assert.AreEqual(link1, link2.Previous);
        }



    }
}
