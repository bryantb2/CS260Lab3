using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListCustom
{
    public class Node
    {
        //Class Fields
        private char value;

        //Defined and Default Constructor
        public Node(char v, Node next, Node previous)
        {
            this.value = v;
            this.Next = next; //sets the value of the next to the following link
            this.Previous = previous; //sets the value of the next to the previous link
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

        public Node Next { get; set; } = null;

        public Node Previous { get; set; } = null;
    }
}
