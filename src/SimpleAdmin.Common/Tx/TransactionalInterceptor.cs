using System.Reflection;
using System.Transactions;
using Castle.DynamicProxy;

namespace SimpleAdmin.Common.Tx
{
    public class TransactionalInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var attr = invocation.Method.GetCustomAttribute<TransactionalAttribute>();

            using (var scope = new TransactionScope(attr.Option))
            {
                invocation.Proceed();
                scope.Complete();
            }
        }
    }
}
