using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Library.Common.Data
{
    public static class Extension
    {
        public static T GetValueOrDefault<T>(this DataRow row, string key, T defaultValue = default(T))
        {
            if (row.IsNull(key))
                return defaultValue;
            else
                return (T)row[key];
        }

        public static object DbNullIfNull(this object obj)
        {
            return obj != null ? obj : DBNull.Value;
        }

        public static bool IsBetween<T>(this T value, T low, T high)
        where T : IComparable<T>
        {
            return value.CompareTo(low) >= 0 && value.CompareTo(high) <= 0;
        }
        public static T ConvertTo<T>(this IConvertible value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static bool IsNumeric(this string str)
        {
            double val;
            return double.TryParse(str, out val);
        }

        public static DataTable CopyToDataTable2<T>(this IEnumerable<T> source)
        {
            return new ObjectShredder<T>().Shred(source, null, null);
        }

        public static DataTable CopyToDataTable2<T>(this IEnumerable<T> source,
                                                    DataTable table, LoadOption? options)
        {
            return new ObjectShredder<T>().Shred(source, table, options);
        }
    }
}
