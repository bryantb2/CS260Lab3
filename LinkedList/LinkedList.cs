using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentClasses;

namespace LinkedListCustom
{
    public class LinkedList<T> 


    {
        //Class Fields
        //private LinkedList<T> list;
        private Node<T> head;
        private Node<T> tail;
        private int size = 0;

        //tracking aspects of iter and key methods
        private Node<T> iter = null; //keeps track of the node as a key for searching
        private bool hasKeyBeenFound = false;
        private T keyValue;


        //Default Constructor
        public LinkedList()
        {
            //creates a new node, initialized to null, and assigns it to head
            this.head = null;
            this.tail = null;
            this.size = 0;
        }

        //Properties
        public int Size
        {
            get
            {
                return this.size;
            }
        }

        //Methods
        public void AddHead(T value)
        {
            //IF SIZE IS GREATER THAN 1
            //takes the currrent head, assigns it to the next value, a new node/link
            //create a new node
                //assign it the value parameter
                //assign new node to head
            if(this.size > 1)
            {
                Node<T> next = new Node<T>(value, head, null);
                head = next;
                Node<T> temp = head.Next; //assigning a previous value to the previously added node, so it does not equal null
                temp.Previous = next;
                size++;
            }
            //ELSE IF SIZE IS EQUAL TO 1
            //create a new node and assign it to the tail and head
            //create a new node
                //assign it the value parameter
                //assign the next property to temp
                //assign new node to head
            else if(this.size == 1)
            {
                Node<T> next = new Node<T>(value, head, null);
                head = next;
                tail = head.Next; //this is the original head node
                Node<T> temp = head.Next; //assigning a previous value to the previously added node, so it does not equal null
                temp.Previous = next;
                size++;
            }
            //if the list is starting out, the head and tail will both equal the first value inputted
            else if(this.size < 1)
            {
                Node<T> next = new Node<T>(value, null, null);
                head = next;
                tail = next;
                size++;
            }
        }
        
        public void AddTail(T value)
        {
            //IF SIZE IS GREATER THAN 1
            //takes the currrent tail, assigns it to the next value, a new node/link
            //create a new node
            //assign it the value parameter
            //assign new node to tail
            if (this.size > 1)
            {
                Node<T> next = new Node<T>(value, null, tail);
                tail = next;
                Node<T> temp = tail.Previous; //assigning a next value to the previously added node, so it does not equal null
                temp.Next = next;
                size++;
            }
            //ELSE IF SIZE IS EQUAL TO 1
            //create a new node and assign it to the tail and head
            //create a new node
            //assign it the value parameter
            //assign the next property to temp
            //assign new node to tail
            else if (this.size == 1)
            {
                Node<T> next = new Node<T>(value, null, tail);
                tail = next;
                head = tail.Previous; //this is the original head node
                Node<T> temp = tail.Previous; //assigning a next value to the previously added node, so it does not equal null
                temp.Next = next;
                size++;
            }
            //if the list is starting out, the head and tail will both equal the first value inputted
            else if (this.size < 1)
            {
                Node<T> next = new Node<T>(value, null, null);
                head = next;
                tail = next;
                size++;
            }
        }

        public T RemoveHead()
        {
            if (this.size >= 1)
            {
                T output = head.Value;
                head = head.Next; //gets the next node in the sequence and sets it to the head
                size--;
                return output;
            }
            else
            {
                throw new Exception("Cannot remove head from an empty list");
            }
        }

        public T RemoveTail()
        {
            if (this.size >= 1)
            {
                T output = tail.Value;
                tail = tail.Previous;
                size--;
                return output;
            }
            else
            {
                throw new Exception("Cannot remove head from an empty list");
            }

        }

        public bool FindKey(T key) //will find one instance of the value and, if called again, will search for the next if applicable
        {
            //create a node to act as a counter
            //iterate through the list under the
                //condition that the current node is not the last (i.e. NULL)
            //check to see if key has been used previously AND it ran successfully last time
                //if so, start at the iter and search through the list
                //if there are no values that match the iter, set all fields back to default states and return false
            //if value is not equal
                //set iter to the node in which the value exists
                //return true
            //otherwise
                //return false and set iter to null
            Node<T> currentNode;
            if (hasKeyBeenFound == true && keyValue.ToString() == key.ToString()) //if the current and previously used key are the same AND the same key had been found before, start at the iter
            {
                if (iter == tail) //if the found value/node is at the end of the list, start at the beginning and look for the same value
                {
                    currentNode = head;
                    while (currentNode != null)
                    {
                        if (currentNode.Value.ToString() == key.ToString())
                        {
                            iter = currentNode;
                            hasKeyBeenFound = true;
                            keyValue = key;
                            return true;
                        }
                        else if (currentNode == tail)
                        {
                            iter = null;
                            hasKeyBeenFound = false;
                            return false;
                        }
                        currentNode = currentNode.Next;
                    }
                }
                else //if the found value is not at the end of the list
                {
                    currentNode = iter.Next;
                    while (currentNode != null)
                    {
                        if (currentNode.Value.ToString() == key.ToString())
                        {
                            iter = currentNode;
                            hasKeyBeenFound = true;
                            keyValue = key;
                            return true;
                        }
                        else if (currentNode == tail)
                        {
                            iter = null;
                            hasKeyBeenFound = false;
                            return false;
                        }
                        currentNode = currentNode.Next;
                    }
                }
            }
            else //under this, the key does not match the last one used, meaning the user wants to commence a new search
            {
                currentNode = head;
                while (currentNode != null)
                {
                    if (currentNode.Value.ToString() == key.ToString())
                    {
                        iter = currentNode;
                        hasKeyBeenFound = true;
                        keyValue = key;
                        return true;
                    }
                    else if (currentNode == tail)
                    {
                        iter = null;
                        hasKeyBeenFound = false;
                        return false;
                    }
                    currentNode = currentNode.Next;
                }
            }
            return false; //if the code reaches this point, there is a possible internal logic error
        }

        public bool InsertKey(T value)
        {
            //if hasKeyBeenFound is true
                //replace the value within the iter node with the value argument, return true
            //if hasKeyBeenFound is false
                //do not replace the value and return false
            if (hasKeyBeenFound == true)
            {
                iter.Value = value; //sets value
                Node<T> currentNode = iter;
                if (currentNode == head)
                {
                    head = iter; //if the head is equivalent to the iter, then set it to the head
                    return true;
                }
                else
                {
                    while (currentNode != null)
                    {
                        if (currentNode == head)
                        {
                            head = currentNode; //sets head to the new node value
                        }
                        currentNode = currentNode.Previous;
                    }
                    return true; 
                }
            }
            else
            {
                return false; //this means that the FindKey has not been used
            }
        }

        /*(public bool deleteKey(char key)
        {
            //if key is equal to the value in the node
                //delete the node
            //if iter is equal to the key
                //set iter to null
                //return true
            //if key has not been found
                //return false
            Node currentNode = head;
            bool isInMiddleOrEnd = false; //tracks where the current node is in the sequence
            while (currentNode != null)
            {
                if (currentNode.Value == key && currentNode == head)
                {
                    if (currentNode == iter)
                        iter = null;
                    RemoveHead(); //if the head is selected for removal, move forward one
                }
                else if (currentNode.Value == key )
                {
                    if (currentNode == iter)
                        iter = null;

                    isInMiddleOrEnd = true;
                }
                else if (currentNode.Value == key && currentNode == tail)
                {
                    if (currentNode == iter)
                        iter = null;
                    RemoveTail(); //if tail is selected for removal
                    isInMiddleOrEnd = true;
                }
                else
                {
                    return false;
                }
                currentNode = currentNode.Next;
            }

            if (isInMiddleOrEnd == true)
            {

            }
        } */

        public bool FindValue(T value) //only finds first instance of the value
        {
            //create a node to act as a counter
            //iterate through the list under the
            //condition that the current node is not the last (i.e. NULL)
            //return true if value present
            //return false if code breaks out of loop
            Node<T> currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Value.ToString() == value.ToString())
                {
                    return true;
                }
                currentNode = currentNode.Next;
            }
            return false;
        }

        public bool FindRemove(T value)
        {
            //create a node to act as a counter
            //iterate through the list under the
            //condition that the current node is not the last (i.e. NULL)
            //if value present
            //delete the current node
            //return true 
            //if value is not present
            //return false

            //WHAT I NEED TO KNOW:
            //the current node location
            //the previous node location, and the next node location
            Node<T> currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Value.ToString() == value.ToString())
                {
                    bool isNotAtFirstLink = false;
                    T output;
                    if (this.size > 1)
                    {
                        output = currentNode.Value;
                        if (currentNode == head)
                        {
                            currentNode = currentNode.Next; //if the head is selected for removal, move forward one
                        }
                        else if (currentNode == tail)
                        {
                            currentNode = currentNode.Previous; //if the tail is selected for removal, move back one
                            currentNode.Next = null;
                            tail = currentNode;
                            isNotAtFirstLink = true;
                        }
                        else
                        {
                            /*
                            currentNode = currentNode.Previous; //moves to one node behind the chosen one
                            currentNode.Next = currentNode.Next; //sets the next node to one beyond the node chosen for removal
                            */
                            Node<T> prev = currentNode.Previous;
                            Node<T> next = currentNode.Next;
                            prev.Next = next;


                            isNotAtFirstLink = true;
                        }
                        //temp = currentNode;
                        //temp.Previous = currentNode.Previous;
                        //temp.Next = currentNode.Next; //skips the current node and effectively removes it from the chain
                        size--;
                    }
                    else if (this.size == 1)
                    {
                        output = currentNode.Value;
                        currentNode = null;
                        tail = null;
                        size--;
                    }
                    if (isNotAtFirstLink == true) //sets node back to first in series, assuming that the currentNode references a node in the middle of the list
                    {
                        while (currentNode.Previous != null)
                        {
                            currentNode = currentNode.Previous;
                        }
                    }
                    this.head = currentNode;
                    return true;
                }
                currentNode = currentNode.Next; //acts as a counter
            }
            return false;
        }

        public void AppendList(LinkedList<T> list2)
        {
            //iterate through the second list
            //add currentNode to tail of first list
            //stop when the next value is null
            Node<T> currentNode = list2.head;
            bool endOfStream = false;
            while (currentNode != null)
            {
                if (currentNode == list2.tail)
                {
                    this.AddTail(currentNode.Value);
                    endOfStream = true; //stops the list from moving past the end
                }
                else if (endOfStream == false)
                {
                    this.AddTail(currentNode.Value);
                }
                currentNode = currentNode.Next;
            }
        }
        
        public string DisplayList()
        {
            if(typeof(T)== typeof(Student))
            {
                //iterate through the list
                //so long as the node is not null, add the value to the string
                string output = "";
                Node<T> currentNode = head;
                bool endOfStream = false;
                while (currentNode != null)//|| currentNode != tail.Next)
                {
                    if (currentNode == tail)
                    {
                        T tempStudent = currentNode.Value;
                        output += tempStudent.ToString() + " ";
                        endOfStream = true; //this ensures that no node values past the end of tail can be printed
                    }
                    else if (currentNode != tail && endOfStream == false)
                    {
                        T tempStudent = currentNode.Value;
                        output += tempStudent.ToString() + " ";
                    }
                    currentNode = currentNode.Next;
                }
                return output;
            }
            else
            {
                //iterate through the list
                //so long as the node is not null, add the value to the string
                string output = "";
                Node<T> currentNode = head;
                bool endOfStream = false;
                while (currentNode != null)//|| currentNode != tail.Next)
                {
                    if (currentNode == tail)
                    {
                        output += currentNode.Value + " ";
                        endOfStream = true; //this ensures that no node values past the end of tail can be printed
                    }
                    else if (currentNode != tail && endOfStream == false)
                    {
                        output += currentNode.Value + " ";
                    }
                    currentNode = currentNode.Next;
                }
                return output;
            }
        }

        public void AddSorted(T value)
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
