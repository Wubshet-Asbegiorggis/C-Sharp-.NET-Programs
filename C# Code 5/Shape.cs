using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Very often you want to define a
// class that you don't want to be
// instantiated. In that case an 
// Abstract class may be the way to
// go. 

namespace ConsoleApp5
{
    abstract class Shape
    {
        public string Name { get; set; }

        // You can define non-abstract
        // methods in an abstract class
        public virtual void GetInfo()
        {
            Console.WriteLine($"This is a {Name}");
        }

        // We want subclasses to override
        // this method so mark it as abstract
        // You can only make abstract methods 
        // in abstract classes
        public abstract double Area();

    }
}
