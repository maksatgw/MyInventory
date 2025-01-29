using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Application.DTO.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
