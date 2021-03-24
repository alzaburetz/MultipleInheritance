using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MultipleInheritance
{
    public static class LinqExtention
    {
        public static IEnumerable<TResult> FullJoin<TSource, TSecond, TResult>(this IEnumerable<TSource> persons, IEnumerable<TSecond> weathers, Func<TSecond, string> weatherPredicate, Func<TSource, string> personPredicate, Func<TSource, TSecond, TResult> filter)
        {
            var left = persons.ToLookup(personPredicate);
            var right = weathers.ToLookup(weatherPredicate);

            foreach (var innerGrouping in right)
                    foreach (var item in innerGrouping)
                        yield return filter(default(TSource), item);

            foreach (var outerGrouping in left)
                foreach (var item in right[outerGrouping.Key].DefaultIfEmpty())
                    foreach (var item_ in outerGrouping)
                        yield return filter(item_, item);
        }
    }
}
