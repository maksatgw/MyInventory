using MyInventory.Application.DTO.AssignmentDtos;
using MyInventory.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Application.Abstract
{
    public interface IAssignmentService : IGenericService<AssignmentDto, CreateAssignmentDto, UpdateAssignmnetDto>
    {
    }
}
