using System;

namespace LinkedListExample
{
    public class Demo
    {
        public static void Main()
        {   
           /*
            LinkedListExample<string> LL = new LinkedListExample<string>();

            LL.AddLast("LAST");
            LL.AddFirst("FIRST");
            LL.PrintAll();

            Console.WriteLine();
            LinkedListExample<int> LLNum = new LinkedListExample<int>();

            LLNum.AddLast(2);
            LLNum.AddFirst(3);
            LLNum.PrintAll();*/

            Node fact = new Node();

            Console.WriteLine(fact.Factorial(5));

        }
    }

    public class Node
    {
        public Node next;
        public Object data;


        public int Factorial(int n)
        {
            if(n == 0 || n == 1)
            {
                return 1;
            }

            return n * (Factorial(n-1));
        }

    }

    public class LinkedListExample<T>
    {
        // Reference to the topmost element in the LinkedList Structure
        Node head;

        public void AddFirst(T t)
        {
            Node addItemFirst = new Node();
            addItemFirst.data = t;

            addItemFirst.next = head;
            head = addItemFirst;
        }

        public void PrintAll()
        {
            if(head == null)
            {
                Console.WriteLine("LinkedList Structure Empty");
            }
            else
            {
                Node current = head;

                while(current != null)
                {
                    Console.WriteLine("Item:" + current.data);
                    current = current.next;
                }
            }
        }

        public void AddToPosition(T t, int pos)
        {
            if(head == null)
            {
                head = new Node();
                head.data = t;
                head.next = null;
            }
            else
            {
                Node current = head;

                while(current.next != null)
                {
                    
                }
            }
        }

        public void AddLast(T t)
        {
            if(head == null)
            {
                head = new Node();
                head.data = t;
                head.next = null;
            }
            else
            {
                Node current = head;

                while(current.next != null)
                {
                    current = current.next;
                }

                Node addItemLast = new Node();
                addItemLast.data = t;
            }
        }
    }   
}

