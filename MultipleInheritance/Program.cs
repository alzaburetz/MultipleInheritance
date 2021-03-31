using System;
using System.Collections.Generic;
using System.Linq;

namespace MultipleInheritance
{
    class Program
    {
        public static IEnumerable<int> GetEnumeration()
        {
            return Enumerable.Range(0, 100);
        }

        static void Main(string[] args)
        {
            foreach(var item in GetEnumeration().MyWhere(x => x % 2 == 0).MyTake(10000000))
            {
                Console.WriteLine(item);
            }
        }
    }
}
