using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleAdmin.Common.Autofac.Extensions;
using SimpleAdmin.Common.DateAndTime;
using SimpleAdmin.Common.Redis;
using SimpleAdmin.Common.Redis.Abstractions;
using SimpleAdmin.Common.Tx;
using SimpleAdmin.Common.Validation;
using SimpleAdmin.Common.Validation.Abstractions;
using SimpleAdmin.Contracts.Users.Services;
using SimpleAdmin.Services;
using System;
using System.Reflection;

namespace SimpleAdmin.App
{
    public class Startup
    {
        private const string ModelValidationKey = "EnableModelValidation";
        private const string RedisConnStrName = "Redis";
        private const string SqlConnStrName = "SqlDb";

        private readonly EnvironmentConfig _environmentConfig;

        public Startup(IConfiguration configuration)
        {
            _environmentConfig = new EnvironmentConfig.Builder()
                .EnableModelValidation(configuration.GetValue<bool>(ModelValidationKey))
                .RedisConnectionString(configuration.GetConnectionString(RedisConnStrName))
                .SqlConnectionString(configuration.GetConnectionString(SqlConnStrName))
                .Build();
        }

        public IContainer ApplicationContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container:
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the React files will be served from this directory:
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            var builder = new ContainerBuilder();
            builder.Populate(services);

            RegisterProviders(builder);
            RegisterInterceptors(builder);

            // Redis:
            builder.RegisterType<RedisConnectionFactory>()
                .As<IRedisConnectionFactory>()
                .WithParameter("connectionString", _environmentConfig.RedisConnectionString)
                .SingleInstance();

            builder.RegisterType<RedisService>().SingleInstance();

            // Register application modules:
            RegisterUsersModule(builder);

            // Validation:
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).As<IValidator>();
            builder.RegisterType<ValidationService>().WithProperty("Enabled", _environmentConfig.EnableModelValidation);

            // Build IoC Container:
            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline:
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }

        private void RegisterInterceptors(ContainerBuilder container)
        {
            container.RegisterType<TransactionalInterceptor>();
            container.RegisterType<ValidationInterceptor>();
        }

        private void RegisterProviders(ContainerBuilder container)
        {
            container.RegisterType<DateTimeProvider>().SingleInstance();
        }

        private void RegisterUsersModule(ContainerBuilder container)
        {
            container.RegisterService<IUserService, UserService>();
        }
    }
}
