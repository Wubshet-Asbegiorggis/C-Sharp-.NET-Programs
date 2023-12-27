using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp10
{
    // This time I'll cover multiple functions 
    // you can use to work with lists of data
    // including Lambda, Where, ToList, Select,
    // Zip, Aggregate and Average

    class Program
    {
        // Delegate that is assigned a Lambda
        // expression
        delegate double doubleIt(double val);

        static void Main(string[] args)
        {
            // Like we did with predicates earlier
            // Lambda expressions allow you to 
            // use anonymous methods that define
            // the input parameters on the left 
            // and the code to execute on the right

            // Assign a Lambda to the delegate
            doubleIt dblIt = x => x * 2;
            Console.WriteLine($"5 * 2 = {dblIt(5)}");

            // You don't have to use delegates though
            // Here we'll search through a list to 
            // find all the even numbers
            List<int> numList = new List<int> { 1, 9, 2, 6, 3 };

            // Put the number in the list if the 
            // condition is true
            var evenList = numList.Where(a => a % 2 == 0).ToList();

            foreach (var j in evenList)
                Console.WriteLine(j);

            // Add values in a range to a list
            var rangeList = numList.Where(x => (x > 2) || (x < 9)).ToList();

            foreach (var k in rangeList)
                Console.WriteLine(k);

            // Find the number of heads and tails in
            // a list 1 = H, 2 = T

            // Generate our list
            List<int> flipList = new List<int>();
            int i = 0;
            Random rnd = new Random();
            while (i < 100)
            {
                flipList.Add(rnd.Next(1, 3));
                i++;
            }

            // Print out the heads and tails
            Console.WriteLine("Heads : {0}",
                flipList.Where(a => a == 1).ToList().Count());
            Console.WriteLine("Tails : {0}",
                flipList.Where(a => a == 2).ToList().Count());

            // Find all names starting with s
            var nameList = new List<string> { "Doug", "Sally", "Sue" };

            var sNameList = nameList.Where(x => x.StartsWith("S"));

            foreach (var m in sNameList)
                Console.WriteLine(m);

            // ---------- SELECT ----------
            // Select allows us to execute a function 
            // on each item in a list

            // Generate a list from 1 to 10
            var oneTo10 = new List<int>();
            oneTo10.AddRange(Enumerable.Range(1, 10));

            var squares = oneTo10.Select(x => x * x);

            foreach (var l in squares)
                Console.WriteLine(l);

            // ---------- ZIP ----------
            // Zip applies a function to two lists 
            // Add values in 2 lists together
            var listOne = new List<int>(new int[] { 1, 3, 4 });
            var listTwo = new List<int>(new int[] { 4, 6, 8 });

            var sumList = listOne.Zip(listTwo, (x, y) => x + y).ToList();

            foreach (var n in sumList)
                Console.WriteLine(n);

            // ---------- AGGREGATE ----------
            // Aggregate performs an operation on 
            // each item in a list and carries the 
            // results forward 

            // Sum values in a list
            var numList2 = new List<int>() { 1, 2, 3, 4, 5 };
            Console.WriteLine("Sum : {0}",
                numList2.Aggregate((a, b) => a + b));

            // ---------- AVERAGE ----------
            // Get the average of a list of values
            var numList3 = new List<int>() { 1, 2, 3, 4, 5 };

            // AsQueryable allows you to manipulate the
            // collection with the Average function
            Console.WriteLine("AVG : {0}",
                numList3.AsQueryable().Average());

            // ---------- ALL ----------
            // Determines if all items in a list
            // meet a condition
            var numList4 = new List<int>() { 1, 2, 3, 4, 5 };

            Console.WriteLine("All > 3 : {0}",
                numList4.All(x => x > 3));

            // ---------- ANY ----------
            // Determines if any items in a list
            // meet a condition
            var numList5 = new List<int>() { 1, 2, 3, 4, 5 };

            Console.WriteLine("Any > 3 : {0}",
                numList5.Any(x => x > 3));

            // ---------- DISTINCT ----------
            // Eliminates duplicates from a list
            var numList6 = new List<int>() { 1, 2, 3, 2, 3 };

            Console.WriteLine("Distinct : {0}",
                string.Join(", ", numList6.Distinct()));

            // ---------- EXCEPT ----------
            // Receives 2 lists and returns values not
            // found in the 2nd list
            var numList7 = new List<int>() { 1, 2, 3, 2, 3 };
            var numList8 = new List<int>() { 3 };

            Console.WriteLine("Except : {0}",
                string.Join(", ", numList7.Except(numList8)));

            // ---------- INTERSECT ----------
            // Receives 2 lists and returns values that
            // both lists have
            var numList9 = new List<int>() { 1, 2, 3, 2, 3 };
            var numList10 = new List<int>() { 2, 3 };

            Console.WriteLine("Intersect : {0}",
                string.Join(", ", numList9.Intersect(numList10)));

        }

    }

}