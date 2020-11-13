namespace KS.Applications.Common
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public static class EnumExtensions
    {
        public static string GetName<T>(this T source)
        {
            return GetAttributeValue(source, a => a.Name);
        }

        public static string GetShortName<T>(this T source)
        {
            return GetAttributeValue(source, a => a.ShortName);
        }

        public static IEnumerable<T> GetEnumValues<T>()
             where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().OrderBy(it => it);
        }

        private static string GetAttributeValue<T>(this T source, Func<DisplayAttribute, string> valueSelector)
        {
            var field = source.GetType().GetField(source.ToString());

            var attributes = (DisplayAttribute[])field.GetCustomAttributes(
                typeof(DisplayAttribute), false);

            return attributes != null && attributes.Length > 0 ? valueSelector(attributes[0]) : source.ToString();
        }
    }
}
