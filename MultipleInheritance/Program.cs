using System;
using System.Collections.Generic;
using System.Linq;

namespace MultipleInheritance
{
    class Program
    {
        public static MyIterator<int> GetEnumeration()
        {
            return new MyIterator<int>(Enumerable.Range(0, 100).ToArray());
        }

        static void Main(string[] args)
        {
            foreach(var item in GetEnumeration().MyWhere(x => x % 2 == 0).MyTake(5))
            {
                Console.WriteLine(item);
            }
        }
    }
}
