using System.Reflection;
using NLayer.Repository;
using NLayer.Service.Mapping;
using Autofac;
using NLayer.Repository.Repositories;
using NLayer.Core.Repositories;
using NLayer.Service.Services;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository.UnitOfWorks;

namespace NLayer.Web.Modules
{
	public class RepoServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder
                .RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IGenericRepository<>))
                .InstancePerLifetimeScope();

            builder
                .RegisterGeneric(typeof(Service<>))
                .As(typeof(IService<>))
                .InstancePerLifetimeScope();

            builder
                .RegisterType<UnitOfWork>()
                .As<IUnitOfWork>();

            builder
                .RegisterAssemblyTypes(apiAssembly, repoAssembly!, serviceAssembly!)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope(); // same as AddScoped 

            builder
                .RegisterAssemblyTypes(apiAssembly, repoAssembly!, serviceAssembly!)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope(); // same as AddScoped
        }
    }
}