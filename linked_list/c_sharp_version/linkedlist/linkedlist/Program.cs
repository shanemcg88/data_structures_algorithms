using System;

namespace linkedlist
{
    class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList();
            linkedList.InsertStart(3);
            linkedList.InsertStart(2);
            linkedList.InsertStart(1);
            linkedList.InsertEnd(50);
            linkedList.Traverse();
            linkedList.SizeOfList();

            Console.WriteLine("---------------");

            linkedList.Remove(2);
            linkedList.Traverse();
            linkedList.SizeOfList();

            linkedList.Remove(4);

        }
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
        public int numOfNodes = 0;
        public Node head = null;

        public void InsertStart(int data)
        {
            numOfNodes += 1;
            var newNode = new Node(data);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                newNode.nextNode = head;
                head = newNode;
            }
        }

        public void InsertEnd(int data)
        {
            numOfNodes += 1;
            var newNode = new Node(data);
            var actualNode = head;

            while (actualNode.nextNode != null)
            {
                actualNode = actualNode.nextNode;
            }
            actualNode.nextNode = newNode;
        }

        public void Remove(int data)
        {
            if (head == null)
                return;

            Node previousNode = new Node(null);
            Node actualNode = head;

            do
            {
                previousNode = actualNode;
                actualNode = actualNode.nextNode;

                if (actualNode == null)
                {
                    Console.WriteLine("Couldn't find item: " + data);
                    return;
                }

                if (actualNode.data == data || previousNode == null)
                {
                    previousNode.nextNode = actualNode.nextNode;
                    numOfNodes -= 1;
                }
            }
            while (actualNode.data != data && actualNode != null);

        }

        public int SizeOfList()
        {
            return numOfNodes;
        }

        public void Traverse()
        {
            Node actualNode = head;

            while (actualNode != null)
            {
                Console.WriteLine(actualNode.data);
                actualNode = actualNode.nextNode;
            }
        }
    }
}
