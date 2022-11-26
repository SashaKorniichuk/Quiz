using Microsoft.AspNetCore.Identity;

namespace QuizApplication.DAL.Entity
{
    public class User : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
    }
}
