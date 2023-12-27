using System;
using System.Linq;

// Used for ArrayLists
using System.Collections;

// Used for Dictionary
using System.Collections.Generic;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            // Collections can resize unlike arrays

            // #region provides a way to collapse
            // long blocks of code

            // ---------- ARRAYLISTS ----------
            #region ArrayList Code

            // ArrayLists are resizable arrays
            // that can hold multiple data types
            ArrayList aList = new ArrayList();

            aList.Add("Bob");
            aList.Add(40);

            // Number of items in list
            Console.WriteLine("Count: {0}",
                aList.Count);

            // The capacity automatically increases
            // as items are added
            Console.WriteLine("Capacity: {0}",
                aList.Capacity);

            ArrayList aList2 = new ArrayList();

            // Add an object array
            aList2.AddRange(new object[] { "Mike", "Sally", "Egg" });

            // Add 1 array list to another
            aList.AddRange(aList2);

            // You can sort the list if the types
            // are the same
            aList2.Sort();
            aList2.Reverse();

            // Insert at the 2nd position
            aList2.Insert(1, "Turkey");

            // Get the 1st 2 items
            ArrayList range = aList2.GetRange(0, 2);

            /*
            // Remove the first item
            aList2.RemoveAt(0);

            // Remove the 1st 2 items
            aList2.RemoveRange(0, 2);
            */

            // Search for a match starting at the provided
            // index. You can also find the last index
            // with LastIndexOf
            Console.WriteLine("Turkey Index : {0}",
                aList2.IndexOf("Turkey", 0));

            // Cycle through the list
            foreach (object o in range)
            {
                Console.WriteLine(o);
            }

            // Convert an ArrayList into a string array
            string[] myArray = (string[])aList2.ToArray(typeof(string));

            // Convert a string array into an ArrayList
            string[] customers = { "Bob", "Sally", "Sue" };
            ArrayList custArrayList = new ArrayList();
            custArrayList.AddRange(customers);

            #endregion


            // ---------- DICTIONARIES ----------
            #region Dictionary Code

            // Dictionaries store key value pairs
            // To create them define the data
            // type for the key and the value
            Dictionary<string, string> superheroes = new Dictionary<string, string>();

            superheroes.Add("Clark Kent", "Superman");
            superheroes.Add("Bruce Wayne", "Batman");
            superheroes.Add("Barry West", "Flash");

            // Remove a key / value
            superheroes.Remove("Barry West");

            // Number of keys
            Console.WriteLine("Count : {0}",
                superheroes.Count);

            // Check if a key is present
            Console.WriteLine("Clark Kent : {0}",
                superheroes.ContainsKey("Clark Kent"));

            // Get the value for the key and store it
            // in a string

            superheroes.TryGetValue("Clark Kent", out string test);

            Console.WriteLine($"Clark Kent : {test}");

            // Cycle through key value pairs
            foreach (KeyValuePair<string, string> item in superheroes)
            {
                Console.WriteLine("{0} : {1}",
                    item.Key,
                    item.Value);
            }

            // Clear a dictionary
            superheroes.Clear();


            #endregion

            // ---------- QUEUES ----------
            #region Queue Code
            // Queue 1st in 1st Out Collection

            // Create a Queue
            Queue queue = new Queue();

            // Add values
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            // Is item in queue
            Console.WriteLine("1 in Queue : {0}",
                queue.Contains(1));

            // Remove 1st item from queue
            Console.WriteLine("Remove 1 : {0}",
                queue.Dequeue());

            // Look at 1st item but don't remove
            Console.WriteLine("Peek 1 : {0}",
                queue.Peek());

            // Copy queue to array
            object[] numArray = queue.ToArray();

            // Print array
            Console.WriteLine(string.Join(",", numArray));

            // Print queue items
            foreach (object o in queue)
            {
                Console.WriteLine($"Queue : {o}");
            }

            // Clear the queue
            queue.Clear();


            #endregion

            // ---------- STACKS ----------
            #region Queue Code
            // Stack Last in 1st Out Collection

            // Create a stack
            Stack stack = new Stack();

            // Put items on the stack
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Get but don't remove item
            Console.WriteLine("Peek 1 : {0}",
                stack.Peek());

            // Remove item
            Console.WriteLine("Pop 1 : {0}",
                stack.Pop());

            // Does item exist on stack
            Console.WriteLine("Contain 1 : {0}",
                stack.Contains(1));

            // Copy stack to array
            object[] numArray2 = stack.ToArray();

            // Print array
            Console.WriteLine(string.Join(",", numArray2));

            // Print the stack
            foreach (object o in stack)
            {
                Console.WriteLine($"Stack : {o}");
            }
            #endregion

        }

    }

}
