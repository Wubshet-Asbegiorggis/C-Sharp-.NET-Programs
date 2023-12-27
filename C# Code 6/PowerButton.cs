using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class PowerButton : ICommand
    {
        // You can refer to instances using
        // the interface
        IElectronicDevice device;

        // Now we get into the specifics of
        // what happens when the power button
        // is pressed.
        public PowerButton(IElectronicDevice device)
        {
            this.device = device;
        }

        public void Execute()
        {
            device.On();
        }

        // You can provide a way to undo
        // an action just like the power 
        // button does on a remote
        public void Undo()
        {
            device.Off();
        }
    }
}
