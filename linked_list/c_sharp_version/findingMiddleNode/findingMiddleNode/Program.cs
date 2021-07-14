using System;

namespace findingMiddleNode
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList();

            linkedList.Insert(1);
            linkedList.Insert(2);
            linkedList.Insert(3);
            linkedList.Insert(4);
            linkedList.Insert(5);

            linkedList.Traverse();

            linkedList.GetMiddle();
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
            public int numOfNodes = 0;

            public void Insert(int data)
            {
                Node newNode = new Node(data);
                Node currentNode = head;
                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    while (currentNode.nextNode != null)
                    {
                        currentNode = currentNode.nextNode;
                    }

                    currentNode.nextNode = newNode;
                }
                numOfNodes += 1;
            }

            public void GetMiddle()
            {
                Node doubleIteration = head;
                Node singleIteration = head;

                if (numOfNodes == 0)
                    return;
                
                while (doubleIteration.nextNode != null && doubleIteration.nextNode.nextNode != null)
                {
                    doubleIteration = doubleIteration.nextNode.nextNode;
                    singleIteration = singleIteration.nextNode;
                }

                Console.WriteLine("middle node is: " + singleIteration.data);
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
