using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MultipleInheritance
{
    public static class LinqExtention
    {
        public static IEnumerable<dynamic> FullJoin(this IEnumerable<Person> persons, IEnumerable<Weather> weathers, Func<Weather, string> weatherPredicate, Func<Person, string> personPredicate, Func<Person, Weather, Object> filter)
        {
            var personsLookup = persons.ToLookup(x => x.City);
            var weathersLookup = weathers.ToLookup(x => x.City);

            var keys = new HashSet<string>(persons.Select(x => x.City));
            keys.UnionWith(weathersLookup.Select(x => x.Key));

            var join = from key in keys
                       let xa = personsLookup[key]
                       let xb = weathersLookup[key]
                       select  new { first = xa, second = xb };

            return join;
        }
    }
}
