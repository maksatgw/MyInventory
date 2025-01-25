using MyInventory.Domain.Entities;
using MyInventory.Persistence.Context;
using MyInventory.Persistence.Entity.Abstract;
using MyInventory.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Persistence.Entities.Repository
{
    public class AssignmentRepository : GenericRepository<Assignment>, IAssignmentDataAccess
    {
        public AssignmentRepository(MyInventoryDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
