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
        LinkedListCustom.LinkedList<char> linkedList;
        LinkedListCustom.LinkedList<char> linkedList2;
        /*Node<char> link1;
        Node<char> link2;
        Node<char> link3;
        Node<char> link4; */

        [SetUp]
        public void Setup()
        {
            //List container
            linkedList = new LinkedListCustom.LinkedList<char>();
            linkedList2 = new LinkedListCustom.LinkedList<char>();
            //Links
            /*link1 = new Node<char>('a', link2, null);
            link2 = new Node<char>('b', link3, link1);
            link3 = new Node<char>('c', link4, link2);
            link4 = new Node<char>('d', null, link3);*/
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
            Assert.AreEqual('d', removedValue);
            Assert.AreEqual("c b a ", linkedList.DisplayList());
            Assert.AreEqual(preSize, (postSize +1));
        }

        [Test]
        public void RemoveTailTest()
        {
            //also a test of the DisplayList method
            linkedList.AddTail('a'); //head
            linkedList.AddTail('b');
            linkedList.AddTail('c');
            linkedList.AddTail('d'); //tail
            int preSize = linkedList.Size;
            char removedValue = linkedList.RemoveTail();
            int postSize = linkedList.Size;
            //prints backwards
            Assert.AreEqual('d', removedValue);
            Assert.AreEqual("a b c ", linkedList.DisplayList());
            Assert.AreEqual(preSize, (postSize + 1));
            
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

        [Test]
        public void IsEmptyTest()
        {
            bool result = linkedList.IsEmpty();
            Assert.AreEqual(true, result);
        }

        [Test]
        public void FindKey()
        {
            //also a test of the DisplayList method
            linkedList.AddHead('a'); //tail
            linkedList.AddHead('b');
            linkedList.AddHead('c');
            linkedList.AddHead('d'); //head
            Assert.AreEqual(true, linkedList.FindKey('a')); //first run
            Assert.AreEqual(true, linkedList.FindKey('a')); //second run of same value
            Assert.AreEqual(true, linkedList.FindKey('a')); //third run
            Assert.AreEqual(false, linkedList.FindKey('F'));
        }

        [Test]
        public void InsertKeyTest()
        {
            //also a test of the DisplayList method
            linkedList.AddHead('a'); //tail
            linkedList.AddHead('b');
            linkedList.AddHead('c');
            linkedList.AddHead('d'); //head
            Assert.AreEqual(true, linkedList.FindKey('a')); //finds key
            Assert.AreEqual(true, linkedList.InsertKey('F')); //changes key
            Assert.AreEqual(true, linkedList.FindKey('F'));
            Assert.AreEqual(true, linkedList.InsertKey('E'));
            Assert.AreEqual(true, linkedList.FindKey('E'));
            Assert.AreEqual(false, linkedList.FindKey('G'));
            Assert.AreEqual(false, linkedList.InsertKey('G'));
            Assert.AreEqual("d c b E ", linkedList.DisplayList());
        }

        [Test]
        public void InsertKeyWithDuplicateValuesTest()
        {
            //also a test of the DisplayList method
            linkedList.AddHead('a'); //tail
            linkedList.AddHead('b');
            linkedList.AddHead('a');
            linkedList.AddHead('d'); //head
            Assert.AreEqual(true, linkedList.FindKey('a')); //finds key
            Assert.AreEqual(true, linkedList.InsertKey('F')); //changes key
            Assert.AreEqual(true, linkedList.FindKey('a'));
            Assert.AreEqual(true, linkedList.InsertKey('E'));
            Assert.AreEqual(true, linkedList.FindKey('E'));
            Assert.AreEqual(false, linkedList.FindKey('a'));
            Assert.AreEqual("d F b E ", linkedList.DisplayList());
        }

        [Test]
        public void AppendListTest()
        {
            //also a test of the DisplayList method
            //first linkedList
            linkedList.AddHead('a'); //tail
            linkedList.AddHead('b');
            linkedList.AddHead('a');
            linkedList.AddHead('d'); //head

            //second linkedList2
            linkedList.AddHead('a'); //tail
            linkedList.AddHead('b');
            linkedList.AddHead('a');
            linkedList.AddHead('d'); //head

            linkedList.AppendList(linkedList2);
            Assert.AreEqual("d a b a d a b a ", linkedList.DisplayList());
        }
    }
}
