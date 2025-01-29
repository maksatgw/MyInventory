using MyInventory.Application.DTO.EquipmentImageDtos;
using MyInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Application.DTO.EquipmentDtos
{
    public class EquipmentDto
    {
        public int EquipmentId { get; set; }
        public string Brand { get; set; }
        public string? Model { get; set; }
        public string SerialNumber { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public int LocationId { get; set; }
        public string DateAdded { get; set; }
        public string DateUpdated { get; set; }
        //public  Category Category { get; set; }
        //public  Location Location { get; set; }
        //public  Assignment Assignment { get; set; }
        //public  List<AssignmentHistory> AssignmentHistories { get; set; }
        public List<EquipmentImageDto> EquipmentImages { get; set; }
    }
}
