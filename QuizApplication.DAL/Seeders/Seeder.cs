using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using QuizApplication.DAL.Entity;

namespace QuizApplication.DAL.Seeders
{
    public partial class Seeder
    {
        private static Random random = new Random();
        public async static Task SeedData(IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                await SeedCategories(context);
                await SeedQuestions(context);
                await SeedAnswers(context);
                await SeedUsersAsync(context, userManager);
            }
        }
        private static Array getArrayOfEnum<T>() where T : Enum
        {
            Type type = typeof(T);
            Array result = type.GetEnumValues();
            return result;
        }
    }
}
