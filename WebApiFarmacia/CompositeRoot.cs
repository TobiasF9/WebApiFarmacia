using Services.Implementations;
using Services.Interfaces;

namespace WebApiMedicines
{
    public static class CompositeRoot
    {
        public static void DependencyInjection(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IMedicineService, MedicineService>();
            builder.Services.AddScoped<ISellerService, SellerService>();
        }
    }
}
