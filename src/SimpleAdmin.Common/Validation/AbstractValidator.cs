using SimpleAdmin.Common.Validation.Abstractions;
using SimpleAdmin.Utils;
using System;

namespace SimpleAdmin.Common.Validation
{
    public abstract class AbstractValidator<T> : IValidator
    {
        public Type SupportedType()
        {
            return typeof(T);
        }

        public abstract void Validate(T target);

        void IValidator.Validate(object target)
        {
            Assert.NotNull(target, nameof(target));

            if ((target is T) == false)
            {
                throw new ArgumentException($"Target object is not {typeof(T)} type.");
            }

            Validate((T)target);
        }
    }
}
