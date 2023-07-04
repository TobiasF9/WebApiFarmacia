using Services.Implementations;
using Services.Interfaces;

namespace WebApiMedicines
{
    public static class CompositeRoot
    {
        public static void DependencyInjection(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IMedicineService, MedicineService>();
            builder.Services.AddScoped<ISellsService, SellsService>();
            builder.Services.AddScoped<IAuthService, AuthService>();
        }
    }
}