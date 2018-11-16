using Castle.DynamicProxy;
using SimpleAdmin.Utils;
using System.Reflection;

namespace SimpleAdmin.Common.Validation
{
    public class ValidationInterceptor : IInterceptor
    {
        private readonly ValidationService _validationService;

        public ValidationInterceptor(ValidationService validationService)
        {
            Assert.NotNull(validationService, nameof(validationService));

            _validationService = validationService;
        }

        public void Intercept(IInvocation invocation)
        {
            int idx = 0;

            foreach (var p in invocation.Method.GetParameters())
            {
                var attr = p.GetCustomAttribute<ValidAttribute>();

                if (attr != null)
                {
                    _validationService.Validate(p.ParameterType, invocation.Arguments[idx]);
                }

                idx++;
            }

            invocation.Proceed();
        }
    }
}
