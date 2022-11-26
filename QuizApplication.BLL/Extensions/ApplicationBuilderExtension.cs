using Microsoft.AspNetCore.Builder;
using QuizApplication.DAL.Seeders;

namespace QuizApplication.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder AddSeeder(this IApplicationBuilder app)
        {
            Seeder.SeedData(app);
            return app;
        }
    }
}
