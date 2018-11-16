using System;
using System.Transactions;

namespace SimpleAdmin.Common.Tx
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TransactionalAttribute : Attribute
    {
        public TransactionalAttribute(TransactionScopeOption option = TransactionScopeOption.Required)
        {
            Option = option;
        }

        public TransactionScopeOption Option { get; }
    }
}
