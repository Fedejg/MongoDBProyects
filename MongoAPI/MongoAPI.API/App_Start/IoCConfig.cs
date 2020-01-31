using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using Autofac;
using MongoAPI.BL.DependencyInjection;

namespace MongoAPI.API.App_Start
{
    public class IoCConfig
    {
        public static IContainer Container { get; set; }

        public static T GetInstance<T>()
        {
            return Container.Resolve<T>();
        }

        public static void Configure()
        {
            var builder = new ContainerBuilder();

            ServicesContainerHelper.AddConfiguration(builder);
            RegisterControllers(builder);

            Container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }

        private static void RegisterControllers(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }
    }
}