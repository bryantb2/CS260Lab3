using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class NodeClass
    {
        //Class Fields
        private char value;
        private NodeClass next = null;

        //Defined and Default Constructor
        public NodeClass(char v, NodeClass next)
        {
            this.value = v;
            this.next = next; //sets the value of the next to the other links
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

        public NodeClass Next
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
    }
}
