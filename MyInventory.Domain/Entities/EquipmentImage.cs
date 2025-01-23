using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Domain.Entities
{
    public class EquipmentImage
    {
        public int EquipmentImageId { get; set; }
        public int EquipmentId { get; set; }
        public string Path { get; set; }

        [ForeignKey("EquipmentId")]
        public virtual Equipment Equipment { get; set; }
    }
}
