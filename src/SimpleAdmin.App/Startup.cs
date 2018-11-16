using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IContainer ApplicationContainer { get; private set; }

        public IConfiguration Configuration { get; }

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

            // Register interceptors:
            RegisterInterceptors(builder);

            // Register application services:
            builder.RegisterType<UserService>()
                .As<IUserService>()
                .EnableClassInterceptors()
                .InterceptedBy(typeof(TransactionalInterceptor), typeof(ValidationInterceptor))
                .SingleInstance();

            // Validation:
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).As<IValidator>();
            builder.RegisterType<ValidationService>();

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
    }
}
