using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Application.DTO.LocationDtos
{
    public class UpdateLocationDto
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
