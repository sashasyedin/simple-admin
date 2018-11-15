using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleAdmin.Utils
{
    public static class Assert
    {
        public static void NotNull(object instance, string name)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(name, $"Parameter {name} cannot be null");
            }
        }

        public static void NotEmpty<T>(IEnumerable<T> items, string name)
        {
            if (items.Any() == false)
            {
                throw new ArgumentException($"Parameter {name} must contain items");
            }
        }

        public static void NotNullOrEmpty<T>(IEnumerable<T> items, string name)
        {
            NotNull(items, name);
            NotEmpty(items, name);
        }

        public static void NotNullOrWhiteSpace(string str, string name)
        {
            NotNull(str, name);

            if (str.Trim() == string.Empty)
            {
                throw new ArgumentException($"Parameter {name} cannot be white-space", name);
            }
        }

        public static void GreaterThan<T>(T instance, string name, T greaterThan)
            where T : struct, IComparable
        {
            if (instance.CompareTo(greaterThan) <= 0)
            {
                throw new ArgumentOutOfRangeException(name, $"Parameter {name} must be greater than {greaterThan}");
            }
        }

        public static void GreaterThanZero(decimal instance, string name)
        {
            GreaterThan(instance, name, 0);
        }

        public static void All<T>(IEnumerable<T> collection, Action<T> validateAction)
        {
            foreach (var element in collection)
            {
                validateAction(element);
            }
        }
    }
}
