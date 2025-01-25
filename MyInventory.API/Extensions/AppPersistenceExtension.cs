using MyInventory.Persistence.Entities.Repository;
using MyInventory.Persistence.Entity.Abstract;
using System.Runtime.CompilerServices;

namespace MyInventory.API.Extensions
{
    public static class AppPersistenceExtension 
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            AddPersistenceDIContainer(services);
        }
        public static void AddPersistenceDIContainer(this IServiceCollection services) { 
        
            services.AddScoped<IEquipmentDataAccess, EquipmentRepository>();
            services.AddScoped<ICategoryDataAccess, CategoryRepository>();
            services.AddScoped<ILocationDataAccess, LocationRepository>();
            services.AddScoped<IAssignmentDataAccess, AssignmentRepository>();
            services.AddScoped<IAssignmentHistoryDataAccess, AssignmentHistoryRepository>();
            services.AddScoped<IEquipmentImageDataAccess, EquipmentImageRepository>();
            
        }
    }
}
