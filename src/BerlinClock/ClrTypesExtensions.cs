using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BerlinClock
{
    internal static class ClrTypesExtensions
    {
        public static void Populate<T>(this T[] arr, Func<int> limitationFunc, Func<int, T> value)
        {
            for (int i = 0; i < limitationFunc(); i++)
            {
                arr[i] = value(i);
            }
        }

        public static int GroupToInt(this Match match, int groupIndex)
        {
            return int.Parse(match.Groups[groupIndex].Value);
        }

        public static void AppendLine<T>(this StringBuilder stringBuilder,
                                     IEnumerable<T> collection, Func<T, string> getValue)
        {
            stringBuilder.Append(collection, getValue);
            stringBuilder.AppendLine();
        }

        public static void Append<T>(this StringBuilder stringBuilder,
                                     IEnumerable<T> collection, Func<T, string> getValue)
        {
            foreach (var item in collection)
            {
                stringBuilder.Append(getValue(item));
            }
        }
    }
}