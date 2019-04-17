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
    class ListTest
    {
        LinkedList linkedList;
        Node link1;
        Node link2;
        Node link3;
        Node link4;

        [SetUp]
        public void Setup()
        {
            //List container
            linkedList = new LinkedList();
            //Links
            link1 = new Node('a', link2, null);
            link2 = new Node('b', link3, link1);
            link3 = new Node('c', link4, link2);
            link4 = new Node('d', null, link3);
        }

        [Test]
        public void BasicTest()
        {
            Assert.AreEqual(true, true);
        }

        [Test]
        public void AddHeadTest()
        {
            //also a test of the DisplayList method
            //tail
            linkedList.AddHead('a');
            linkedList.AddHead('b');
            linkedList.AddHead('c');
            linkedList.AddHead('d');
            //head
            //prints backwards
            Assert.AreEqual("d c b a ", linkedList.DisplayList());
        }

        [Test]
        public void AddTailTest()
        {
            //also a test of the DisplayList method
            //head
            linkedList.AddTail('a');
            linkedList.AddTail('b');
            linkedList.AddTail('c');
            linkedList.AddTail('d');
            //tail
            //prints backwards
            Assert.AreEqual("a b c d ", linkedList.DisplayList());
        }

        [Test]
        public void RemoveHeadTest()
        {
            //also a test of the DisplayList method
            linkedList.AddHead('a'); //tail
            linkedList.AddHead('b');
            linkedList.AddHead('c');
            linkedList.AddHead('d'); //head
            int preSize = linkedList.Size;
            char removedValue = linkedList.RemoveHead();
            int postSize = linkedList.Size;
            //prints backwards
            Assert.AreEqual("c b a ", linkedList.DisplayList());
            Assert.AreEqual(preSize, (postSize +1));
            Assert.AreEqual('d', removedValue);
        }

        [Test]
        public void FindValueTest()
        {
            //also a test of the DisplayList method
            linkedList.AddHead('a'); //tail
            linkedList.AddHead('b');
            linkedList.AddHead('c');
            linkedList.AddHead('d'); //head
            Assert.AreEqual(true, linkedList.FindValue('a'));
            Assert.AreEqual(false, linkedList.FindValue('D'));
        }

        [Test]
        public void FindRemoveTest()
        {
            //also a test of the DisplayList method
            linkedList.AddHead('a'); //tail
            linkedList.AddHead('b');
            linkedList.AddHead('c');
            linkedList.AddHead('d'); //head
            Assert.AreEqual(true, linkedList.FindRemove('a'));
            Assert.AreEqual("d c b ", linkedList.DisplayList());
        }

















    }
}
