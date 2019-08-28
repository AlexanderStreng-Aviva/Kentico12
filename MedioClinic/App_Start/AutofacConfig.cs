using System.Globalization;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Business.DependencyInjection;
using Business.Repository;
using Business.Repository.Home;
using Business.Services;
using Business.Services.Context;
using MedioClinic.Config;
using MedioClinic.Controllers;
using MedioClinic.Utils;

namespace MedioClinic
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterSource(new CmsRegistrationSource());

            builder.RegisterAssemblyTypes(typeof(IService).Assembly)
                .Where(x => x.IsClass && !x.IsAbstract && typeof(IService).IsAssignableFrom(x))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(IRepository).Assembly)
                .Where(x => x.IsClass && !x.IsAbstract && typeof(IRepository).IsAssignableFrom(x))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterType<SiteContextService>().As<ISiteContextService>()
                .WithParameter((parameter, context) => parameter.Name == "currentSiteCulture",
                    (parameter, context) => CultureInfo.CurrentUICulture.Name)
                .WithParameter((parameter, context) => parameter.Name == "siteName",
                    (parameter, context) => AppConfig.SiteName)
                .InstancePerRequest();

            //Automapper 
            builder.Register(c => GetMapperInstance()).As<IMapper>().InstancePerRequest();

            builder.RegisterType<BusinessDependencies>().As<IBusinessDependencies>().InstancePerRequest();
            builder.RegisterType<FileManagementHelper>().As<IFileManagementHelper>().InstancePerRequest();
            builder.RegisterType<ErrorHelper>().As<IErrorHelper>().InstancePerRequest();

            // Resolves the dependencies
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }

        private static IMapper GetMapperInstance()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddMaps(typeof(HomeProfile)));
            return mapperConfig.CreateMapper();
        }
    }
}