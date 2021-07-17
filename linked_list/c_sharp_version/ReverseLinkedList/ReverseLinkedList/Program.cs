using System;

namespace ReverseLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();

            linkedList.Insert(1);
            linkedList.Insert(2);
            linkedList.Insert(3);
            linkedList.Insert(4);
            linkedList.Insert(5);

            linkedList.Traverse();

            linkedList.Reverse();
            linkedList.Traverse();
        }

        public class Node
        {
            public int? data;
            public Node nextNode = null;

            public Node(Nullable<int> dataInput)
            {
                data = dataInput;
            }
        }

        public class LinkedList
        {
            public Node head;
            
            public void Insert(int data)
            {
                Node newNode = new Node(data);
                Node currentNode = head;

                if (head == null)
                    head = newNode;
                else
                {
                    while (currentNode.nextNode != null)
                    {
                        currentNode = currentNode.nextNode;
                        
                    }
                    currentNode.nextNode = newNode;
                }

            }

            public void Reverse()
            {
                Node currentNode = head;
                Node nextNode = null;
                Node prevNode = null;

                while (currentNode.nextNode != null)
                {
                    nextNode = currentNode.nextNode;
                    currentNode.nextNode = prevNode;
                    prevNode = currentNode;
                    currentNode = nextNode;    
                }

                head = prevNode;
            }

            public void Traverse()
            {
                Node currentNode = head;
                if (head != null)
                {
                    while (currentNode != null)
                    {
                        Console.WriteLine(currentNode.data);

                        currentNode = currentNode.nextNode;
                    }

                }

            }
        }
    }
}
