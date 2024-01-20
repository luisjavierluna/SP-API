using Application.Enums;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Persistence.Seeds
{
    public static class DefaultBasicUser
    {
        public static async Task SeedAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new User
            {
                FirstName = "Javier",
                LastName = "Arellano",
                UserName = "userBasic",
                Email = "userBasic@mail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$word");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                }
            }
        }
    }
}
