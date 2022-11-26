using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuizApplication.DAL;
using QuizApplication.DAL.Entity;
using QuizApplication.DAL.Repositories;
using QuizApplication.DAL.Repositories.Abstarctions;

namespace QuizApplication.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterDbContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsActions)
        {
            services.AddDbContext<DataContext>(optionsActions);
            return services;
        }
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(EFGenericRepository<>));
            return services;
        }
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
        public static IServiceCollection RegisterIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User,IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<DataContext>();

            return services;
        }
    }
}
