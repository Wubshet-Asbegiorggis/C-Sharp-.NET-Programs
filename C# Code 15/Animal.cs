using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

// With serialization you can store the state 
// of an object in a file stream, pass it to
// a remote network

namespace ConsoleApp15
{
    // Defines that you want to serialize this class
    [Serializable()]
    public class Animal : ISerializable
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int AnimalID { get; set; }

        public Animal() { }

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
            return string.Format("{0} weighs {1} lbs and is {2} inches tall",
                Name, Weight, Height);
        }

        // Serialization function (Stores Object Data in File)
        // SerializationInfo holds the key value pairs
        // StreamingContext can hold additional info
        // but we aren't using it here
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Assign key value pair for your data
            info.AddValue("Name", Name);
            info.AddValue("Weight", Weight);
            info.AddValue("Height", Height);
            info.AddValue("AnimalID", AnimalID);
        }

        // The deserialize function (Removes Object Data from File)
        public Animal(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the properties
            Name = (string)info.GetValue("Name", typeof(string));
            Weight = (double)info.GetValue("Weight", typeof(double));
            Height = (double)info.GetValue("Height", typeof(double));
            AnimalID = (int)info.GetValue("AnimalID", typeof(int));
        }
    }
}
