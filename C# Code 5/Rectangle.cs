using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double length,
            double width)
        {
            Name = "Rectangle";
            Length = length;
            Width = width;
        }

        public override double Area()
        {
            return Length * Width;
        }

        // You can replace the method using override
        public override void GetInfo()
        {
            // Execute the base version
            base.GetInfo();
            Console.WriteLine($"It has a Length of {Length} and Width of {Width}");
        }
    }
}
