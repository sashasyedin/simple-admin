using System;

namespace SimpleAdmin.Common.Validation.Abstractions
{
    public interface IValidator
    {
        Type SupportedType();

        void Validate(object target);
    }
}
