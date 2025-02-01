using MyInventory.Infrastructure.Configurations;

namespace MyInventory.API.Extensions
{
    public static class AppInfrastructureExtension
    {

        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ImgBBSettings>(configuration.GetSection("ImgBB"));
        }

    }
}
