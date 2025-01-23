using Microsoft.EntityFrameworkCore;
using MyInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Persistence.Context
{
    public class MyInventoryDbContext : DbContext
    {
        public MyInventoryDbContext(DbContextOptions<MyInventoryDbContext> options) : base(options) 
        {
        }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentHistory> AssignmentHistories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentImage> EquipmentImages { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
