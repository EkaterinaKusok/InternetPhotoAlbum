using System.Data.Entity;
using BLL.Interfacies.Services;
using BLL.Services;
using DAL.Interfacies.Repository;
using DAL.Repositories;
using Ninject;
using Ninject.Web.Common; 
using ORM;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<DbContext>().To<PhotoAlbumDbContext>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<PhotoAlbumDbContext>().InSingletonScope();
            }

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IUserProfileService>().To<UserProfileService>();
            kernel.Bind<IPhotoService>().To<PhotoService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IRatingService>().To<RatingService>();

            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IPhotoRepository>().To<PhotoRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<IRatingRepository>().To<RatingRepository>();
            kernel.Bind<IUserProfileRepository>().To<UserProfileRepository>();
        }
    }
}
