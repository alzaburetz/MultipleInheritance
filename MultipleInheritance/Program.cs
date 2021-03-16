using System;
using System.Collections.Generic;
using System.Linq;

namespace MultipleInheritance
{
    struct Test
    {
        public int Flag { get; set; }
        public int Value { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
        public string City { get; set; }
    }

    public class Weather
    {
        public string City { get; set; }
        public string Now { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>
    {
        new Person { Name = "Alexey", City = "Moscow" },
        new Person { Name = "Vladimir", City = "St. Peterburg" },
        new Person { Name = "Sergey", City = "Vladimir" },
    };

            var weathers = new List<Weather>
    {
        new Weather { Now = "Solar", City = "Moscow" },
        new Weather { Now = "Rainy", City = "Tallin" },
    };

            var join = persons.FullJoin(weathers, x => x.City, y => y.City, (first, second) => new { first, second});

            foreach (var j in join)
            {
                Console.WriteLine($"{ j.first?.Name ?? "NULL" } | { j.second?.Now ?? "NULL" }");
            }
        }
    }
}
