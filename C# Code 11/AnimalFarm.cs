using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    // IEnumerable provides for iteration 
    // over a collection
    class AnimalFarm : IEnumerable
    {
        // Holds list of Animals
        private List<Animal> animalList = new List<Animal>();

        public AnimalFarm(List<Animal> animalList)
        {
            this.animalList = animalList;
        }

        public AnimalFarm()
        {
        }

        // Indexer for AnimalFarm created with this[]
        public Animal this[int index]
        {
            get { return (Animal)animalList[index]; }
            set { animalList.Insert(index, value); }
        }

        // Returns the number of values in the 
        // collection
        public int Count
        {
            get
            {
                return animalList.Count;
            }
        }

        // Returns an enumerator that is used to 
        // iterate through the collection
        IEnumerator IEnumerable.GetEnumerator()
        {
            return animalList.GetEnumerator();
        }


    }
}
