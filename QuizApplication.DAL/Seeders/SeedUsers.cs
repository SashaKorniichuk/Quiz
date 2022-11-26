using Microsoft.AspNetCore.Identity;
using QuizApplication.DAL.Entity;

namespace QuizApplication.DAL.Seeders
{
    public partial class Seeder
    {
        private async static Task SeedUsersAsync(DataContext context, UserManager<User> userManager)
        {
            if (!context.Users.Any())
            {
                var user = UserCreator();
                await CreateUserAsync(userManager, user);

                var user1 = UserCreator("user-1","user1@gmail.com");
                await CreateUserAsync(userManager, user1);
            }
        }

        private async static Task CreateUserAsync(UserManager<User> userManager, User user, string password = "Qwerty-1")
        {
             await userManager.CreateAsync(user, password);
        } 

        private static User UserCreator(string name = "user", string email = "user@gmail.com")
        {
            return new User
            {
                Name=name,
                UserName = name,
                Email=email
            };
        }
    }
}
