using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {

        static void Main(string[] args)
        {
            Animal whiskers = new Animal()
            {
                Name = "Whiskers",
                Sound = "Meow"
            };

            Dog grover = new Dog()
            {
                Name = "Grover",
                Sound = "Woof",
                Sound2 = "Grrrrr"
            };

            // Demonstrate changing the protected
            // field sound
            grover.Sound = "Wooooof";

            whiskers.MakeSound();
            grover.MakeSound();

            // Define the AnimalIDInfo
            whiskers.SetAnimalIDInfo(12345, "Sally Smith");
            grover.SetAnimalIDInfo(12346, "Paul Brown");

            whiskers.GetAnimalIDInfo();

            // Test the inner class
            Animal.AnimalHealth getHealth = new Animal.AnimalHealth();

            Console.WriteLine("Is my animal healthy : {0}", getHealth.HealthyWeight(11, 46));

            // You can define 2 Animal objects but have
            // one actually be a Dog type. 
            Animal monkey = new Animal()
            {
                Name = "Happy",
                Sound = "Eeeeee"
            };

            Animal spot = new Dog()
            {
                Name = "Spot",
                Sound = "Wooooff",
                Sound2 = "Geerrrr"
            };

            // The problem is that if you call a 
            // function in Animal it won't call
            // the overridden method in Dog unless
            // the method that might be overridden
            // is marked virtual
            spot.MakeSound();

            // This is an example of how Polymorphism
            // allows a subclass to override a method
            // in the super class and even if the 
            // subclass is defined as the super class
            // type the correct method will be called


            Console.ReadLine();
        }
    }

}