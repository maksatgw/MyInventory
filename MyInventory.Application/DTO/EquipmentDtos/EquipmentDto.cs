using MyInventory.Application.DTO.CategoryDtos;
using MyInventory.Application.DTO.EquipmentImageDtos;
using MyInventory.Application.DTO.LocationDtos;
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
        public string DateAdded { get; set; }
        public string DateUpdated { get; set; }
        public CategoryDto Category { get; set; }
        public LocationDto Location { get; set; }
        public List<EquipmentImageDto> EquipmentImages { get; set; }
    }
}
