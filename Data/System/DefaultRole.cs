using Express_Management.AppSettings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Express_Management.Data.System
{
    public static class DefaultRole
    {
        public static async Task GenerateAsync(
            RoleManager<IdentityRole>? roleManager,
            IOptions<ApplicationConfiguration>? appConfig
            )
        {
            if (roleManager != null)
            {
                await roleManager.CreateAsync(new IdentityRole(appConfig?.Value.RoleInternalName ?? string.Empty));
                await roleManager.CreateAsync(new IdentityRole(appConfig?.Value.RoleCustomerName ?? string.Empty));
                await roleManager.CreateAsync(new IdentityRole(appConfig?.Value.RoleVendorName ?? string.Empty));

            }
        }
    }
}
