using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.Phonebook.DAL.Infrastructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace PS.Phonebook.DAL.Data
{
    public static class DataInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var scope = serviceProvider.CreateScope();
            await using var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            var isExists = context!.GetService<IDatabaseCreator>() 
                is RelationalDatabaseCreator databaseCreator
                && await databaseCreator.ExistsAsync();

            if (isExists) { return; }


            var roles = AppData.Roles.ToArray();
            var roleStore = new RoleStore<IdentityRole>(context);
            foreach (var role in roles)
            {
                if(!context!.Roles.Any(x => x.Name == role))
                {
                    await roleStore.CreateAsync(new IdentityRole(role)
                    {
                        NormalizedName = role.ToUpper()
                    });
                }
            }


            const string username = "pixelArt@gmail.com";

            if(context!.Users.All(x => x.Email == username))
            {
                return;
            }

            var user = new IdentityUser
            {
                UserName = username,
                NormalizedUserName = username.ToUpper(),
                Email = username,
                NormalizedEmail = username.ToUpper(),
                PhoneNumber = "80297777777",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };


            var passwordHasher = new PasswordHasher<IdentityUser>();
            var passwordHash = passwordHasher.HashPassword(user, "PixelArt*999");
            user.PasswordHash = passwordHash;

            var userStore = new UserStore<IdentityUser>(context);
            var identityResult = await userStore.CreateAsync(user);

            if (!identityResult.Succeeded)
            {
                var message = string.Join(", ", identityResult.Errors.Select(x => $"{x.Code}: {x.Description}"));
                throw new NullReferenceException(message);
            }

            var userManager = scope.ServiceProvider.GetService<UserManager<IdentityUser>>();

            foreach (var role in roles)
            {
                var identityResultRole = await userManager!.AddToRolesAsync(user, roles);
                if (!identityResultRole.Succeeded)
                {
                    var message = string.Join(", ", identityResultRole.Errors.Select(x => $"{x.Code}: {x.Description}"));
                    throw new NullReferenceException(message);
                }

            }

            await context.SaveChangesAsync();
        }
    }
}
