using MyInventory.Application.Abstract;
using MyInventory.Application.Concrete;
using MyInventory.Application.Mapper.AutoMapperProfile;

namespace MyInventory.API.Extensions
{
    public static class AppApplicationExtension
    {
        public static void AddApplictonServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapProfile).Assembly);

            AddApplicationDIContainer(services);
        }

        public static void AddApplicationDIContainer(this IServiceCollection services)
        {
            services.AddScoped<IEquipmentService, EquipmentService>();
            services.AddScoped<IEquipmentImageService, EquipmentImageService>();
        }

    }
}
