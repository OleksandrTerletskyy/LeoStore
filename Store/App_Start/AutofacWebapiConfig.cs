using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Store.Data.DatabaseContext;
using Store.Data.Infrastructure;
using Store.Data.Repositories.Abstract;
using Store.Data.Repositories.Concrete;
using Store.Mappings;

namespace Store
{
	public class AutofacWebapiConfig
	{
		private static IContainer _container;

		public static void Initialize(HttpConfiguration config)
		{
			Initialize(config, RegisterServices(new ContainerBuilder()));
		}

		public static void Initialize(HttpConfiguration config, IContainer container)
		{
			config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
		}

		private static IContainer RegisterServices(ContainerBuilder builder)
		{
			builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

			builder.RegisterType<StoreContext>()
				.As<DbContext>()
				.InstancePerRequest();

			builder.RegisterType<StoreContextFactory>()
				.As<IDbContextFactory>()
				.InstancePerRequest();

			builder.RegisterGeneric(typeof(EntityBaseRepository<>))
				.As(typeof(IEntityBaseRepository<>))
				.InstancePerRequest();

			builder.RegisterType<ProductMapper>()
				.As<ProductMapper>()
				.InstancePerRequest();
			builder.RegisterType<TagMapper>()
				.As<TagMapper>()
				.InstancePerRequest();

			_container = builder.Build();
			return _container;
		}
	}
}