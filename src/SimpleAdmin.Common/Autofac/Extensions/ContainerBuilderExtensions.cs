using Autofac;
using Autofac.Builder;
using Autofac.Extras.DynamicProxy;
using SimpleAdmin.Common.Tx;
using SimpleAdmin.Common.Validation;

namespace SimpleAdmin.Common.Autofac.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static IRegistrationBuilder<TImplementer, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            RegisterService<TInterface, TImplementer>(this ContainerBuilder builder)
            where TImplementer : TInterface
        {
            return builder.RegisterType<TImplementer>()
                .As<TInterface>()
                .EnableClassInterceptors()
                .InterceptedBy(typeof(TransactionalInterceptor), typeof(ValidationInterceptor))
                .SingleInstance();
        }

        public static IRegistrationBuilder<TImplementer, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            RegisterRepository<TInterface, TImplementer>(this ContainerBuilder builder)
            where TImplementer : TInterface
        {
            return builder.RegisterType<TImplementer>()
                .As<TInterface>()
                .SingleInstance();
        }
    }
}
