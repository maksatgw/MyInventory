using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Domain.Entities
{
    public class Assignment
    {
        public int AssignmentId { get; set; }
        public int EquipmentId { get; set; }
        public int UserId { get; set; }
        public DateTime AssignedDate { get; set; }
        public string? AssignmentFilePath { get; set; }

        [ForeignKey("EquipmentId")]
        public virtual Equipment Equipment { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
