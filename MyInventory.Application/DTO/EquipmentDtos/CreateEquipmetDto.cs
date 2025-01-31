﻿using Microsoft.AspNetCore.Http;
using MyInventory.Application.DTO.EquipmentImageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Application.DTO.EquipmentDtos
{
    public class CreateEquipmetDto
    {
        public string Brand { get; set; }
        public string? Model { get; set; }
        public string SerialNumber { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public int LocationId { get; set; }
        public string DateAdded { get; set; }
        public string DateUpdated { get; set; } = DateTime.Now.ToString();
        
    }
}
