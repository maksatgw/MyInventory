using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Application.DTO.EquipmentImageDtos
{
    public class EquipmentImageDto
    {
        public int EquipmentImageId { get; set; }
        public int EquipmentId { get; set; }
        public string Path { get; set; }
    }
}
