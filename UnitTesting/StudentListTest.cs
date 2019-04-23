using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedListCustom;
using StudentClasses;
using NUnit.Framework;

namespace UnitTesting
{
    [TestFixture]
    class StudentListTest
    {
        //Links and Nodes for List
        LinkedListCustom.LinkedList<Student> studentList;
        LinkedListCustom.LinkedList<Student> studentList2;

        //Default Student Objects
        Student studentA = new Student("Sally",18);
        Student studentB = new Student("Jerry", 40);
        Student studentC = new Student("Brian", 27);
        Student studentD = new Student("Terry", 35);

        //Extra Student Objects for Data Manipulation
        Student studentE = new Student("Bob", 20);
        Student studentF = new Student("Marry", 16);

        //student never assigned
        Student studentZ = new Student("studentZ", 200);


        [SetUp]
        public void Setup()
        {
            //List container
            studentList = new LinkedListCustom.LinkedList<Student>();
            studentList2 = new LinkedListCustom.LinkedList<Student>();
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
            studentList.AddHead(studentA); //tail
            studentList.AddHead(studentB);
            studentList.AddHead(studentC);
            studentList.AddHead(studentD); //head
            //head
            //prints backwards
            Assert.AreEqual("Terry Brian Jerry Sally ", studentList.DisplayList());
        }
        
        [Test]
        public void AddTailTest()
        {
            //also a test of the DisplayList method
            //head
            studentList.AddTail(studentA);
            studentList.AddTail(studentB);
            studentList.AddTail(studentC);
            studentList.AddTail(studentD);
            //tail
            //prints backwards
            Assert.AreEqual("Sally Jerry Brian Terry ", studentList.DisplayList());
        }
        
        [Test]
        public void RemoveHeadTest()
        {
            //also a test of the DisplayList method
            studentList.AddHead(studentA); //tail
            studentList.AddHead(studentB);
            studentList.AddHead(studentC);
            studentList.AddHead(studentD); //head
            int preSize = studentList.Size;
            Student removedValue = studentList.RemoveHead();
            int postSize = studentList.Size;
            //prints backwards
            Assert.AreEqual(studentD, removedValue);
            Assert.AreEqual("Brian Jerry Sally ", studentList.DisplayList());
            Assert.AreEqual(preSize, (postSize + 1));
        }
        
        [Test]
        public void RemoveTailTest()
        {
            //also a test of the DisplayList method
            //head
            studentList.AddTail(studentA);
            studentList.AddTail(studentB);
            studentList.AddTail(studentC);
            studentList.AddTail(studentD); 
            //tail
            int preSize = studentList.Size;
            Student removedValue = studentList.RemoveTail();
            int postSize = studentList.Size;
            //prints backwards
            Assert.AreEqual(studentD, removedValue);
            Assert.AreEqual("Sally Jerry Brian ", studentList.DisplayList());
            Assert.AreEqual(preSize, (postSize + 1));

        }
        
        [Test]
        public void FindValueTest()
        {
            //also a test of the DisplayList method
            studentList.AddHead(studentA); //tail
            studentList.AddHead(studentB);
            studentList.AddHead(studentC);
            studentList.AddHead(studentD); //head
            Assert.AreEqual(true, studentList.FindValue(studentC));
            Assert.AreEqual(false, studentList.FindValue(studentZ));
        }
        
        [Test]
        public void FindRemoveTest()
        {
            //also a test of the DisplayList method
            studentList.AddHead(studentA); //tail
            studentList.AddHead(studentB);
            studentList.AddHead(studentC);
            studentList.AddHead(studentD); //head
            Assert.AreEqual(true, studentList.FindRemove(studentC));
            Assert.AreEqual("Terry Jerry Sally ", studentList.DisplayList());
        }
        
        [Test]
        public void IsEmptyTest()
        {
            bool result = studentList.IsEmpty();
            Assert.AreEqual(true, result);
        }
        
        [Test]
        public void FindKey()
        {
            //also a test of the DisplayList method
            studentList.AddHead(studentA); //tail
            studentList.AddHead(studentB);
            studentList.AddHead(studentA);
            studentList.AddHead(studentD); //head
            Assert.AreEqual(true, studentList.FindKey(studentA)); //first run
            Assert.AreEqual(true, studentList.FindKey(studentA)); //second run of same value
            Assert.AreEqual(true, studentList.FindKey(studentA)); //third run
            Assert.AreEqual(false, studentList.FindKey(studentZ));
        }
        
        [Test]
        public void InsertKeyTest()
        {
            //also a test of the DisplayList method
            studentList.AddHead(studentA); //tail
            studentList.AddHead(studentB);
            studentList.AddHead(studentA);
            studentList.AddHead(studentD); //head
            Assert.AreEqual(true, studentList.FindKey(studentA)); 
            Assert.AreEqual(true, studentList.InsertKey(studentZ)); //inserts Z at A
            Assert.AreEqual(true, studentList.FindKey(studentZ)); 
            Assert.AreEqual(true, studentList.InsertKey(studentE)); //inserts E at Z
            Assert.AreEqual(true, studentList.FindKey(studentE));
            Assert.AreEqual(false, studentList.FindKey(studentF)); //false insert
            Assert.AreEqual(false, studentList.InsertKey(studentF));
            Assert.AreEqual("Terry Bob Jerry Sally ", studentList.DisplayList());
            //from head to tail:
                //studentD, studentE, studentB, studentA
        }
        
        [Test]
        public void InsertKeyWithDuplicateValuesTest()
        {
            //also a test of the DisplayList method
            studentList.AddHead(studentA); //tail
            studentList.AddHead(studentB);
            studentList.AddHead(studentA);
            studentList.AddHead(studentD); //head
            Assert.AreEqual(true, studentList.FindKey(studentA)); 
            Assert.AreEqual(true, studentList.InsertKey(studentE)); //inserts E at A
            Assert.AreEqual(true, studentList.FindKey(studentA));
            Assert.AreEqual(true, studentList.InsertKey(studentF)); //inserts F at second A
            Assert.AreEqual(true, studentList.FindKey(studentF)); 
            Assert.AreEqual(false, studentList.FindKey(studentA));
            Assert.AreEqual("Terry Bob Jerry Marry ", studentList.DisplayList());
        }
        
        [Test]
        public void AppendListTest()
        {
            //also a test of the DisplayList method
            //first linkedList
            studentList.AddHead(studentA); //tail
            studentList.AddHead(studentB);
            studentList.AddHead(studentC);
            studentList.AddHead(studentD); //head

            //second linkedList2
            studentList2.AddHead(studentE); //tail
            studentList2.AddHead(studentF);
            studentList2.AddHead(studentC);
            studentList2.AddHead(studentD); //head

            studentList.AppendList(studentList2);
            Assert.AreEqual("Terry Brian Jerry Sally Terry Brian Marry Bob ", studentList.DisplayList());
        }
    }
}

