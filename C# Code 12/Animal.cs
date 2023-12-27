using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    class Animal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int AnimalID { get; set; }

        public Animal(string name = "No Name",
            double weight = 0,
            double height = 0)
        {
            Name = name;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return string.Format("{0} weighs {1}lbs and is {2} inches tall",
                Name, Weight, Height);
        }
    }
}
