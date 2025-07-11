
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Model;
using System;
using System.Threading.Tasks;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<Utilizador>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

        string[] roles = new[] { "Administrador", "Administrativo", "Utente" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new ApplicationRole { Name = role });
        }

        var adminEmail = "admin@xpto.com";
        var admin = await userManager.FindByEmailAsync(adminEmail);
        if (admin == null)
        {
            var user = new Utilizador
            {
                UserName = adminEmail,
                Email = adminEmail,
                Nome = "Administrador XPTO",
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(user, "Admin123@");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Administrador");
            }
        }
    }
}
