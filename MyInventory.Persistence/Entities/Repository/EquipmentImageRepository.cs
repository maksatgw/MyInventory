﻿using MyInventory.Domain.Entities;
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
    public class EquipmentImageRepository : GenericRepository<EquipmentImage>, IEquipmentImageDataAccess
    {
        public EquipmentImageRepository(MyInventoryDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
