using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Application.DTO.AssignmentDtos
{
    public class UpdateAssignmentDto
    {
        public int AssignmentId { get; set; }
        public int EquipmentId { get; set; }
        public string AssignedUser { get; set; }
        public string AssignedUserLocation { get; set; }
        public DateTime AssignedDate { get; set; }
        public string? AssignmentFilePath { get; set; }
    }
}
