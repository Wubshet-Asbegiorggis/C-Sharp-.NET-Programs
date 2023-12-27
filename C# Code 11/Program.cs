using System;
using System.Linq;
using System.Collections.Generic;
using ConsoleApp11;

/*
We’ll learn about IEnumerable, Indexer, Enumerator, Operator Overloading, Custom
Casting, Anonymous Types and more
*/

namespace ConsoleApp11
{
    // Indexers allow you to access items
    // like arrays

    class Program
    {

        static void Main(string[] args)
        {
            // Create an AnimalFarm object
            AnimalFarm myAnimals = new AnimalFarm();

            // Add Animals
            myAnimals[0] = new Animal("Wilbur");
            myAnimals[1] = new Animal("Templeton");
            myAnimals[2] = new Animal("Gander");
            myAnimals[3] = new Animal("Charlotte");

            foreach (Animal i in myAnimals)
            {
                Console.WriteLine(i.Name);
            }

            // Testing operator overloading
            Box box1 = new Box(2, 3, 4);
            Box box2 = new Box(5, 6, 7);

            Box box3 = box1 + box2;

            // Converts the box to a string with
            // ToString
            Console.WriteLine($"Box 3 : {box3}");

            Console.WriteLine($"Box Int : {(int)box3}");

            // Convert an int into a Box
            Box box4 = (Box)4;

            Console.WriteLine($"Box 4 : {(Box)4}");

            // Sometimes you want to build a simple
            // class that contains fields and
            // Anonymous types are great for that
            var shopkins = new { Name = "Shopkins", Price = 4.99 };

            Console.WriteLine("{0} cost ${1}",
                shopkins.Name, shopkins.Price);

            // Anonymous types can also be stored 
            // in an array

            var toyArray = new[] { new {
                Name = "Yo-Kai Pack", Price = 4.99 },
                new { Name = "Legos", Price = 9.99 } };

            // You can loop through the array
            foreach (var item in toyArray)
            {
                Console.WriteLine("{0} costs ${1}",
                    item.Name, item.Price);
            }

            Console.WriteLine();

            Console.ReadLine();

        }

    }

}