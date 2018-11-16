using SimpleAdmin.Common.Validation.Abstractions;
using SimpleAdmin.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace SimpleAdmin.Common.Validation
{
    public class ValidationService
    {
        private readonly ConcurrentDictionary<Type, IValidator> _validators;

        public ValidationService()
        {
            _validators = new ConcurrentDictionary<Type, IValidator>();
        }

        public ValidationService(IEnumerable<IValidator> validators)
            : this()
        {
            foreach (var validator in validators)
            {
                AddValidator(validator);
            }
        }

        public bool Enabled { get; set; } = true;

        public void AddValidator(IValidator validator)
        {
            Assert.NotNull(validator, nameof(validator));

            _validators[validator.SupportedType()] = validator;
        }

        public IValidator GetValidator(Type type)
        {
            Assert.NotNull(type, nameof(type));

            _validators.TryGetValue(type, out IValidator validator);
            return validator;
        }

        public void Validate(Type type, object value)
        {
            Assert.NotNull(type, nameof(type));
            Assert.NotNull(value, nameof(value));

            if (Enabled == false)
            {
                return;
            }

            var validator = GetValidator(type);

            if (validator != null)
            {
                validator.Validate(value);
                return;
            }

            if (typeof(IValidatable).IsAssignableFrom(type))
            {
                ((IValidatable)value).Validate();
                return;
            }

            throw new Exception($"To support validation class {type} should implement IValidatable interface or have Validator.");
        }
    }
}
