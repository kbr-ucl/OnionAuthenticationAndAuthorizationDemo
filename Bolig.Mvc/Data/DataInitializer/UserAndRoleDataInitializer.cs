using Microsoft.AspNetCore.Identity;

namespace Bolig.Mvc.Data.DataInitializer
{
    public static class UserAndRoleDataInitializer
    {
        public static void SeedData(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("johndoe@localhost").Result == null)
            {
                var user = new IdentityUser();
                user.UserName = "johndoe@localhost.dk";
                user.Email = "johndoe@localhost.dk";
                user.EmailConfirmed = true;

                var result = userManager.CreateAsync(user, "P@ssw0rd1!").Result;

                if (result.Succeeded) userManager.AddToRoleAsync(user, "User").Wait();
            }


            if (userManager.FindByEmailAsync("alex@localhost").Result == null)
            {
                var user = new IdentityUser();
                user.UserName = "alex@localhost.dk";
                user.Email = "alex@localhost.dk";
                user.EmailConfirmed = true;


                var result = userManager.CreateAsync(user, "P@ssw0rd1!").Result;

                if (result.Succeeded) userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole();
                role.Name = "User";
                var roleResult = roleManager.CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                var roleResult = roleManager.CreateAsync(role).Result;
            }
        }
    }
}