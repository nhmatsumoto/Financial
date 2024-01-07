using Microsoft.AspNetCore.Identity;
using nhmatsumoto.financial.api.Domain.Entities;
using nhmatsumoto.financial.api.Domain.Enums;

namespace nhmatsumoto.financial.api
{
    public static class IdentityInitializer
    {
        public static async Task InitializeAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await CreateRoles(roleManager);
            await CreateSysAdmin(userManager);
            await CreateEmpresa(userManager);
        }

        private static async Task CreateRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "SysAdmin", "Empresa" };

            foreach (var roleName in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);

                if (!roleExists)
                {
                    // Cria as roles
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        private static async Task CreateSysAdmin(UserManager<AppUser> userManager)
        {
            var sysAdmin = await userManager.FindByNameAsync("sysadmin");

            if (sysAdmin is null)
            {
                sysAdmin = new AppUser
                {
                    UserName = "sysadmin",
                    Email = "sysadmin@test.com",
                    UserType = UserType.SysAdmin
                };

                await userManager.CreateAsync(sysAdmin, "Admin@123");
                await userManager.AddToRoleAsync(sysAdmin, "SysAdmin");
            }
        }

        private static async Task CreateEmpresa(UserManager<AppUser> userManager)
        {
            var empresaUser = await userManager.FindByNameAsync("empresa");

            if (empresaUser is null)
            {
                empresaUser = new AppUser
                {
                    UserName = "empresa",
                    Email = "empresa@example.com",
                    UserType = UserType.Empresa
                };

                await userManager.CreateAsync(empresaUser, "Password@123");
                await userManager.AddToRoleAsync(empresaUser, "Empresa");
            }
        }
    }
}
