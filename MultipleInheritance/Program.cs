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

    public class Result
    {
        public string id => second?.City;
        public Person first;
        public Weather second;
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

            var join = persons.FullJoin<Person, Weather, Result>(weathers, x => x.City, y => y.City,(first, second) => new Result{ first = first, second = second });

            foreach (var j in join)
            {
                Console.WriteLine($"{ j.first?.Name ?? "NULL" }\t\t | { j.second?.Now ?? "NULL" }\t | { j.id ?? "NULL"}");
            }
        }
    }
}
