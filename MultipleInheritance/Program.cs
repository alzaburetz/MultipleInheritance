using System;

namespace MultipleInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            TransportClass plane = new Plane();
            TransportClass car = new Car();
            TransportClass boat = new Boat();

            car.GetTransport();
            boat.GetTransport();
            plane.GetTransport();
        }
    }
}
