using SimpleAdmin.Common.Validation.Abstractions;
using System.Collections.Generic;

namespace SimpleAdmin.Common.Validation
{
    public static class Validation
    {
        public static void Valid(IValidatable instance, string name)
        {
            instance.Validate();
        }

        public static void Valid(IEnumerable<IValidatable> collection, string name)
        {
            foreach (var element in collection)
            {
                element.Validate();
            }
        }
    }
}
