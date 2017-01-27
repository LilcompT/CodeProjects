using System;

public class Node
{
    // Points to the next reference
    public Node next;

    // Contains the data within the node
    public Object data;
}

public class LinkedList
{
    // Reference to the first element in the Linked List
    private Node head;

    public void printAllNodes()
    {
        // Points to the first element
        Node current = head;

        // Until a Node doesn't point to null we want to print the contents of all nodes
        while (current != null)
        {
            // Prints the content to console
            Console.WriteLine(current.data);
            // Points to the next Node
            current = current.next;
        }
    }

    public void AddFirst(Object data)
    {
        // Creates a new Node Object
        Node toAdd = new Node();

        // Assigns data to the Node Object
        toAdd.data = data;

        // Points to the first element in the Structure
        toAdd.next = head;
        // Inserts a new element at the head of the Structure
        head = toAdd;
    }
    
    public void AddLast(Object data)
    {
        // test condition to check if any elements exsist within the structure
        if (head == null)
        {
            // Adds new node to the structure given that the condition holds
            head = new Node();
            // Assigns Data to the Node Object
            head.data = data;
            // Updates the pointer to null indicating the last element
            head.next = null;
        }
        else
        {
            // Creates new Node Object
            Node toAdd = new Node();
            // Assigns data to the node Object
            toAdd.data = data;

            // Points to the first element in the Structure
            Node current = head;
            // Loops through the structure until current node points to null
            while (current.next != null)
            {
                // Updates pointer to the next element in the structure
                current = current.next;
            }

            // While Loop condition fails as null is found and inserts it in the null position
            current.next = toAdd;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Add First:");
        LinkedList myList1 = new LinkedList();

        //myList1.AddFirst("Hello");
        //myList1.AddFirst("Magical");
       // myList1.AddFirst("World");
        myList1.AddLast("This is the last item");
        myList1.printAllNodes();

        Console.WriteLine();

        Console.WriteLine("Add Last:");
        LinkedList myList2 = new LinkedList();

        myList2.AddLast("Hello");
        myList2.AddLast("Magical");
        myList2.AddLast("World");
        myList2.printAllNodes();

        Console.ReadLine();
    }
}