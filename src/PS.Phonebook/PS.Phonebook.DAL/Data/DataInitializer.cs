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
using Microsoft.EntityFrameworkCore;

namespace PS.Phonebook.DAL.Data
{
    public static class DataInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {

            var scope = serviceProvider.CreateScope();
            await using var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            //context! говорю что context не может быть Null, дальше проверяю что DatabaseCreator существует
            var isExists = context!.GetService<IDatabaseCreator>() is RelationalDatabaseCreator databaseCreator &&
                await databaseCreator.ExistsAsync();

            //Если бд существует, то просто возвращаю, ни чем дополнительно не наполняю
            if (isExists)
            {
                return;
            }

            //Если бд не существует, Создать бд
            await context!.Database.MigrateAsync();

            //Получаем все роли
            var roles = AppData.Roles.ToArray();

            //Получаем хранилище ролей
            var roleStore = new RoleStore<IdentityRole>(context);

            foreach (var role in roles)
            {
                if (!context!.Roles.Any(x => x.Name == role))
                {
                    await roleStore.CreateAsync(new IdentityRole(role)
                    {
                        //Устанавливаем имя роли с Высокого регистра
                        NormalizedName = role.ToUpper()
                    });
                }
            }


            const string username = "powerful@space.com";

            //проверяем наличие пользователя в бд
            if (context.Users.Any(x => x.Email == username))
            {
                return;
            }

            var user = new IdentityUser
            {
                Email = username,
                EmailConfirmed = true,
                NormalizedEmail = username.ToUpper(),
                PhoneNumber = "+80297777777",
                UserName = username,
                PhoneNumberConfirmed = true,
                NormalizedUserName = username.ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "PixelArt*999");

            var userStore = new UserStore<IdentityUser>(context);
            var identityResult = await userStore.CreateAsync(user);

            if (!identityResult.Succeeded)
            {
                var message = string.Join(", ", identityResult.Errors.Select(x => $"{x.Code}: {x.Description}"));
                throw new Exception(message);
                //throw new NullReferenceException(message);
            }

            var userManager = scope.ServiceProvider.GetService<UserManager<IdentityUser>>();
            foreach (var role in roles)
            {
                var identityResultRole = await userManager!.AddToRolesAsync(user, roles);
                if (!identityResultRole.Succeeded)
                {
                    var message = string.Join(", ", identityResult.Errors.Select(x => $"{x.Code}: {x.Description}"));
                    throw new Exception(message);
                }
            }

            await context.SaveChangesAsync();

        }
    }
}
