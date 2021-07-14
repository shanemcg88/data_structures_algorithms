using System;

namespace doublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var doublyLinkedList = new DoublyLinkedList();

            doublyLinkedList.Insert(1);
            doublyLinkedList.Insert(2);
            doublyLinkedList.Insert(3);

            doublyLinkedList.TraverseForward();
            doublyLinkedList.TraverseBackward();
        }

        public class Node
        {
            public int data;
            public Node nextNode = null;
            public Node previousNode = null;

            public Node(int dataIn)
            {
                data = dataIn;
            }

        }

        public class DoublyLinkedList
        {
            public int numOfNodes = 0;
            public Node head = null;
            public Node tail = null;

            public void Insert(int data)
            {
                Node newNode = new Node(data);

                if (head == null && tail == null)
                {
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    tail.nextNode = newNode;
                    newNode.previousNode = tail;
                    tail = newNode;
                }
            }

            public void TraverseForward()
            {
                Node currentNode = head;

                while(currentNode != null)
                {
                    Console.WriteLine(currentNode.data);
                    currentNode = currentNode.nextNode;
                }
            }

            public void TraverseBackward()
            {
                Node currentNode = tail;
                
                while(currentNode != null)
                {
                    Console.WriteLine(currentNode.data);
                    currentNode = currentNode.previousNode;
                }
            }
        }

    }
}
