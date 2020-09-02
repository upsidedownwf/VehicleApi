using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleApiServices.HelperModels
{
    public static class ExtensionMethod
    {
        public static IEnumerable<T> Wheres<T>(this IEnumerable<T> data, Func<T, bool> predicate)
        {
            if (data == null)
            {
                //throw new NotImplementedException();
                throw new ArgumentNullException(nameof(data), "source");
            }
            if (predicate == null)
            {

                throw new ArgumentNullException(nameof(predicate), "source");
            }

            foreach (T value in data)
            {
                if (predicate(value)) yield return value;
            }
        }
        public static T FirstorDefaults<T>(this IEnumerable<T> data)
        {
            if (data.Any())return data.ToArray()[0];
            return default(T);
        }
        public static T FirstorDefaults<T>(this IEnumerable<T> data, Func<T, bool> predicate)
        {
            foreach (T value in data)
            {
                if (predicate == null)
                {
                    return value;
                }
                else
                {
                    if (predicate(value)) return value;
                }
            }
            return default(T);
        }
        public static void Main()
        {
            IEnumerable data = new[] { new { Foo = "abc" }, new { Foo = "def" }, new { Foo = "ghi" } };
            var typed = data.Cast(()=> new { Foo = "never used" });
            foreach (var item in typed)
            {
                Console.WriteLine(item.Foo);
            }
            typed.Wheres(x=> x.Foo=="www");
        }

        public static IEnumerable<T> Cast<T>(this IEnumerable source, Func<T> template)
        {
            return Enumerable.Cast<T>(source);
        }
        public static void doublestring(string sss,out string valuess)
        {
            valuess = sss + " waso";
        }
    }
}
