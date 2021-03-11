using System;
using System.Linq;

namespace MultipleInheritance
{
    public class Program
    {

        public static MyEnumerator<int> GetEnumeration()
        {
            int i = 0;
            var result = new MyEnumerator<int>();
            while (i < 1000)
            {
                result.Data.Add(i);
                i++;
            }
            return result;
        }
        public static void Main(string[] args)
        {
            foreach (var item in GetEnumeration().MyWhere(x => x % 2 == 0).MyTake(5))
            {
                Console.WriteLine(item);
            }
        }
    }
}
