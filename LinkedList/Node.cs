using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Node
    {
        //Class Fields
        private char value;
        private Node next = null;
        private Node previous = null;

        //Defined and Default Constructor
        public Node(char v, Node next, Node previous)
        {
            this.value = v;
            this.next = next; //sets the value of the next to the following link
            this.previous = previous; //sets the value of the next to the previous link
        }

        //Properties
        public char Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public Node Next
        {
            get
            {
                return this.next;
            }
            set
            {
                this.next = value;
            }
        }

        public Node Previous
        {
            get
            {
                return this.previous;
            }
            set
            {
                this.previous = value;
            }
        }
    }
}
