using System;
using System.Collections.Generic;
using System.Text;

namespace MultipleInheritance
{
    public abstract class TransportClass
    {
        public abstract void GetTransport();
    }

    public class Boat : TransportClass
    {
        public override void GetTransport()
        {
            Console.WriteLine($"This is a Boat!");
        }
    }

    public class Car : TransportClass
    {
        public override void GetTransport()
        {
            Console.WriteLine("This is a Car");
        }
    }

    public class Plane : TransportClass
    {
        public override void GetTransport()
        {
            Console.WriteLine("This is a Plane!");
        }
    }
}
