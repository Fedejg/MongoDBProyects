using Autofac;
using MongoAPI.DAL;
using MongoAPI.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoAPI.BL.DependencyInjection
{
    public class ServicesContainerHelper
    {
        public static void AddConfiguration(ContainerBuilder builder)
        {
            RegisterBLServices(builder);
            RegisterRepositories(builder);
            RegisterLibraries(builder);
            RegisterMapperModule(builder);
        }

        /// <summary>
        /// Se encarga de registrar los BL en container
        /// </summary>
        /// <param name="builder"></param>
        private static void RegisterBLServices(ContainerBuilder builder)
        {
            builder.RegisterType<ProductBL>().InstancePerRequest();
        }

        /// <summary>
        /// Se encarga de registrar los repositorios en el container
        /// </summary>
        /// <param name="builder"></param>
        private static void RegisterRepositories(ContainerBuilder builder)
        {
            builder.RegisterType<ProductDAL>().As<IProductDAL>();
        }

        /// <summary>
        /// Se encarga de registrar los repositorios en el container
        /// </summary>
        /// <param name="builder"></param>
        private static void RegisterLibraries(ContainerBuilder builder)
        {
            //builder.RegisterType<CiDiService>().As<ICiDiService>();			
        }

        /// <summary>
        /// Se encarga de registrar los mapeos de automapper entre entidades y modelos.
        /// </summary>
        /// <param name="builder"></param>
        private static void RegisterMapperModule(ContainerBuilder builder)
        {
            //builder.RegisterModule(new MappingModule());
        }
    }
}
