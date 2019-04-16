using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class List
    {
        //Class Fields
        private List list;
        private Node head;
        private Node tail;
        private int size = 0;

        //Default Constructor
        public List()
        {
            //creates a new node, initialized to null, and assigns it to head
            this.head = null;
            this.tail = null;
            this.size = 0;
        }

        //Methods
        public void AddHead(char value)
        {
            //IF SIZE IS GREATER THAN 1
            //takes the currrent head, assigns it to the next value in the constructor
            //create a new node
                //assign it the value parameter
                //assign the next property to temp
                //assign new node to head
            if(this.size > 1)
            {
                Node next = new Node(value, head, tail);
                head = next;
                size++;
            }
            //ELSE IF SIZE IS 1
            //create a new node and assign it to the tail and head
            //create a new node
                //assign it the value parameter
                //assign the next property to temp
                //assign new node to head
            else if(this.size == 1)
            {
                Node next = new Node(value, head, tail);
                head = next;
                tail = next;
                size++;
            }
            else if(this.size < 1)
            {
                Node next = new Node(value, head, tail);
                head = next;
                tail = next;
                size++;
            }





        }

        public char RemoveHead()
        {
            //test to see if list has values, if empty throw exception
            //creates a node for temp storage
                //sets head equal to the next item it is referencing
                //decrements size
            if(size >= 1)
            {
                Node temp = head;
                head = head.Next;
                size--;
                return temp.Value;
            }
            else
            {
                throw new Exception("Cannot remove head from an empty list");
            }
            
        }
        
        public bool FindValue(char value)
        {
            //create a node to act as a counter
            //iterate through the list under the
            //condition that the current node is not the last (i.e. NULL)
                //return true if value present
                //return false if code breaks out of loop
            Node currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        public bool FindRemove(char value)
        {
            //create a node to act as a counter
            //iterate through the list under the
            //condition that the current node is not the last (i.e. NULL)
            //if value present
                //delete the current node
                //return true 
            //if value is not present
                //return false
            Node currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    Node temp = head;
                    head = head.Next;
                    size--;
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        public string DisplayList()
        {
            //iterate through the list
                //so long as the node is not null, add the value to the string
            string output = "";
            Node currentNode = head;
            while (currentNode != null)
            {
                output += currentNode.Value + " ";
                currentNode = currentNode.Next;
            }
            return output;
        }

        public void AddSorted(char value)
        {
            //setup a variable to store the head
                //iterate through the list
                //if the next value is higher than the one being stored 
        }

        public bool IsEmpty()
        {
            if (this.size < 1)
                return true;
             return false;
        }













    }
}
