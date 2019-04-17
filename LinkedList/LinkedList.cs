﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListCustom
{
    public class LinkedList
    {
        //Class Fields
        private LinkedList list;
        private Node head;
        private Node tail;
        private int size = 0;

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
        public void AddHead(char value)
        {
            //IF SIZE IS GREATER THAN 1
            //takes the currrent head, assigns it to the next value, a new node/link
            //create a new node
                //assign it the value parameter
                //assign new node to head
            if(this.size > 1)
            {
                Node next = new Node(value, head, null);
                head = next;
                Node temp = head.Next; //assigning a previous value to the previously added node, so it does not equal null
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
                Node next = new Node(value, head, null);
                head = next;
                tail = head.Next; //this is the original head node
                Node temp = head.Next; //assigning a previous value to the previously added node, so it does not equal null
                temp.Previous = next;
                size++;
            }
            //if the list is starting out, the head and tail will both equal the first value inputted
            else if(this.size < 1)
            {
                Node next = new Node(value, null, null);
                head = next;
                tail = next;
                size++;
            }
        }

        public void AddTail(char value)
        {
            //IF SIZE IS GREATER THAN 1
            //takes the currrent tail, assigns it to the next value, a new node/link
            //create a new node
            //assign it the value parameter
            //assign new node to tail
            if (this.size > 1)
            {
                Node next = new Node(value, null, tail);
                tail = next;
                Node temp = tail.Previous; //assigning a next value to the previously added node, so it does not equal null
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
                Node next = new Node(value, null, tail);
                tail = next;
                head = tail.Previous; //this is the original head node
                Node temp = tail.Previous; //assigning a next value to the previously added node, so it does not equal null
                temp.Next = next;
                size++;
            }
            //if the list is starting out, the head and tail will both equal the first value inputted
            else if (this.size < 1)
            {
                Node next = new Node(value, null, null);
                head = next;
                tail = next;
                size++;
            }
        }

        public char RemoveHead()
        {
            if (this.size >= 1)
            {
                char output = head.Value;
                head = head.Next; //gets the next node in the sequence and sets it to the head
                size--;
                return output;
            }
            else
            {
                throw new Exception("Cannot remove head from an empty list");
            }
        }

        public char RemoveTail()
        {
            if (this.size >= 1)
            {
                char output = tail.Value;
                tail = tail.Previous;
                size--;
                return output;
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

            //WHAT I NEED TO KNOW:
                //the current node location
                //the previous node location, and the next node location
            Node currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    bool isNotAtFirstLink = false;
                    char output;
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
                            currentNode = currentNode.Previous; //moves to one node behind the chosen one
                            currentNode.Next = currentNode.Next; //sets the next node to one beyond the node chosen for removal
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

        public string DisplayList()
        {
            //iterate through the list
                //so long as the node is not null, add the value to the string
            string output = "";
            Node currentNode = head;
            bool endOfStream = false;
            while (currentNode != null )//|| currentNode != tail.Next)
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
