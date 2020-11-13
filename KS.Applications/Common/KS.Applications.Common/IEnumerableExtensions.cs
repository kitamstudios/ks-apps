namespace KS.Applications.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Threading.Tasks;

    public static class IEnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            Contract.Requires(enumeration != null);
            Contract.Requires(action != null);

            foreach (var item in enumeration)
            {
                action(item);
            }
        }

        public static void ForEachI<T>(this IEnumerable<T> enumeration, Action<T, int> action)
        {
            Contract.Requires(enumeration != null);
            Contract.Requires(action != null);

            var i = 0;
            foreach (var item in enumeration)
            {
                action(item, i++);
            }
        }

        public static async Task ForEachAsync<T>(this IEnumerable<T> enumeration, Func<T, Task> action)
        {
            Contract.Requires(enumeration != null);
            Contract.Requires(action != null);

            foreach (var item in enumeration)
            {
                await action(item);
            }
        }

        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> e)
        {
            return e ?? Enumerable.Empty<T>();
        }
    }
}
