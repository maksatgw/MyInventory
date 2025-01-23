using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Domain.Entities
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        public string Brand { get; set; }
        public string? Model { get; set; }
        public string SerialNumber { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public int LocationId { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateUpdated { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        public virtual Assignment Assignment { get; set; }
        public virtual List<AssignmentHistory> AssignmentHistories { get; set; }
        public virtual List<EquipmentImage> EquipmentImages { get; set; }

    }
}
