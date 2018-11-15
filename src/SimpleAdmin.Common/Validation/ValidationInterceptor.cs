using Castle.DynamicProxy;
using SimpleAdmin.Utils;
using System.Reflection;

namespace SimpleAdmin.Common.Validation
{
    public class ValidationInterceptor : IInterceptor
    {
        private readonly ValidationService m_validationService;

        public ValidationInterceptor(ValidationService validationService)
        {
            Assert.NotNull(validationService, nameof(validationService));

            m_validationService = validationService;
        }

        public void Intercept(IInvocation invocation)
        {
            int idx = 0;

            foreach (var p in invocation.Method.GetParameters())
            {
                var attr = p.GetCustomAttribute<ValidAttribute>();

                if (attr != null)
                {
                    m_validationService.Validate(p.ParameterType, invocation.Arguments[idx]);
                }

                idx++;
            }

            invocation.Proceed();
        }
    }
}
