using Microsoft.AspNetCore.Http;
using MyInventory.Application.DTO.EquipmentImageDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Application.Abstract
{
    public interface IEquipmentImageService : IGenericService<EquipmentImageDto, CreateEquipmentImageDto, UpdateEquipmentImageDto>
    {
        /// <summary>
        /// Upload image to imageHosting and save the url to the database
        /// </summary>
        /// <param name="file">Required Image</param>
        /// <param name="equipmentId">Required EquipmentId</param>
        /// <returns>CreateEquipmentDto to perform the insert operation</returns>
        Task<CreateEquipmentImageDto> UploadImage(IFormFile file, int equipmentId);
    }
}
