using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using Chapter1.Services.Interfaces;
using Chapter1.Services.Implementation;
using System.Web.Mvc;
using Chapter1.Data.Repository;
using Chapter1.Data.Infrastructure;

namespace Chapter1.App_Start
{
    public static class Bootstrapper
    {

                public static void Run()
        {
            SetAutofacContainer();
            //Configure AutoMapper
            //AutoMapperConfiguration.Configure();
        }
                private static void SetAutofacContainer()
                {
                    var builder = new ContainerBuilder();
                    builder.RegisterControllers(Assembly.GetExecutingAssembly());
                    builder.RegisterType<ViewEmployees>().As<IViewEmployees>().InstancePerHttpRequest();
                    builder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().InstancePerHttpRequest();
                    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerHttpRequest();
                    builder.RegisterAssemblyTypes(typeof(EmployeeRepository).Assembly).Where(t => t.Name.EndsWith("Repository"))
.AsImplementedInterfaces().InstancePerHttpRequest();

                //    builder.RegisterFilterProvider();
                    IContainer container = builder.Build();
                    DependencyResolver.SetResolver(new AutofacDependencyResolver(container));  
                }

    }
}