using MyInventory.Domain.Entities;
using MyInventory.Persistence.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Persistence.Entity.Abstract
{
    public interface IEquipmentImageDataAccess : IGenericDataAccess<EquipmentImage>
    {
    }
}
