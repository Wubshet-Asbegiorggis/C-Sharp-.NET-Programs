using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    // An interface is a class with nothing but
    // abstract methods. Interfaces are used
    // to represent a contract an object may
    // decide to support.

    // Interfaces commonly have names that
    // are adjectives because adjectives
    // modify nouns (Objects). The also
    // describe abstract things

    // It is common to prefix your interfaces with 
    // an I

    interface IDrivable
    {
        // Interfaces can have properties
        int Wheels { get; set; }
        double Speed { get; set; }

        // Classes that inherit an interface
        // must fulfill the contract and 
        // implement every abstract method
        void Move();
        void Stop();
    }
}
