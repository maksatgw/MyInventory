using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Domain.Entities
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual List<Equipment> Equipments { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
