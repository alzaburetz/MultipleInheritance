using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MultipleInheritance
{
    public static class LinqExtention
    {
        public static IEnumerable<dynamic> FullJoin(this IEnumerable<Person> persons, IEnumerable<Weather> weathers, Func<Weather, string> weatherPredicate, Func<Person, string> personPredicate, Func<Person, Weather, Guid, Object> filter)
        {
            var left = persons.ToLookup(personPredicate);
            var right = weathers.ToLookup(weatherPredicate);

            foreach (var innerGrouping in right)
                if (left.Contains(innerGrouping.Key))
                    foreach (var item in innerGrouping)
                        yield return filter(null, item, Guid.NewGuid());

            foreach (var outerGrouping in left)
                foreach (var item in right[outerGrouping.Key].DefaultIfEmpty())
                    foreach (var item_ in outerGrouping)
                        yield return filter(item_, item, Guid.NewGuid());
        }
    }
}
