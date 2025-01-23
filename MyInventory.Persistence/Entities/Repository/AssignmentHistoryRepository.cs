using MyInventory.Domain.Entities;
using MyInventory.Persistence.Context;
using MyInventory.Persistence.Entity.Abstract;
using MyInventory.Persistence.Repository;

namespace MyInventory.Persistence.Entity.Repository
{
    public class AssignmentHistoryRepository : GenericRepository<AssignmentHistory>, IAssignmentHistoryDataAccess
    {
        public AssignmentHistoryRepository(MyInventoryDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
