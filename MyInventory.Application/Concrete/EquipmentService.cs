using AutoMapper;
using MyInventory.Application.Abstract;
using MyInventory.Application.DTO;
using MyInventory.Application.DTO.EquipmentDtos;
using MyInventory.Domain.Entities;
using MyInventory.Persistence.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace MyInventory.Application.Concrete
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentDataAccess _dataAccess;
        private readonly IMapper _mapper;
        public EquipmentService(IEquipmentDataAccess dataAccess, IMapper mapper)
        {
            _dataAccess = dataAccess;
            _mapper = mapper;
        }

        public async Task BulkDelete(List<EquipmentDto> modelList)
        {
            try
            {
                //Map the dto list to entity list
                var equipments = _mapper.Map<List<Equipment>>(modelList);
                //Call the bulk delete method
                await _dataAccess.BulkDeleteAsync(equipments);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public async Task Delete(EquipmentDto model)
        {
            try
            {
                //Map the dto to entity
                var equipment = _mapper.Map<Equipment>(model);
                //Call the delete method
                await _dataAccess.DeleteAsync(equipment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public async Task<EquipmentDto> Get(int id)
        {
            try
            {
                //Get the equipment with the given id and include the EquipmentImages navigation property
                //Then map the entity to dto
                var value = _mapper.Map<EquipmentDto>(await _dataAccess.GetAsync(id,"EquipmentId",x=>x.EquipmentImages));
                //Return the dto
                return value;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public async Task<List<EquipmentDto>> Get()
        {
            try
            {
                //Get all equipments and include the EquipmentImages navigation property
                //Then map the entity list to dto list
                var values = _mapper.Map<List<EquipmentDto>>(await _dataAccess.GetAsync(
                    x=>x.EquipmentImages));
                //Return the dto list
                return values;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public async Task<List<EquipmentDto>> Get(List<int> idList)
        {
            try
            {
                //Get the equipments with the given id list
                var equipments = await _dataAccess.GetAsync(idList, "EquipmentId");
                //Map the entity list to dto list
                var equipmentDtos = _mapper.Map<List<EquipmentDto>>(equipments);
                //Return the dto list
                return equipmentDtos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public async Task<PagedDto<EquipmentDto>> GetPagedEquipments(int pageNumber, int pageSize, int? categoryId = null, int? locationId = null, string? searchQuery = null)
        {
            try
            {
                var equipments = await _dataAccess.GetPagedEquipmentsAsync(pageNumber, pageSize, categoryId, locationId, searchQuery);
                var equipmentDto = _mapper.Map<List<EquipmentDto>>(equipments.Item1);
                var pagedEquipmentDto = new PagedDto<EquipmentDto>
                {
                    Items = equipmentDto,
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalItems = equipments.Item2,
                };
                return pagedEquipmentDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public async Task<EquipmentDto> Insert(CreateEquipmetDto model)
        {
            try
            {
                //Map the dto to entity
                var equipment = _mapper.Map<Equipment>(model);
                //Call the insert method
                await _dataAccess.InsertAsync(equipment);
                //Map the entity to dto
                var equipmentDto = _mapper.Map<EquipmentDto>(equipment);
                //Return the dto
                return equipmentDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public async Task Update(UpdateEquipmentDto model)
        {
            try
            {
                //Map the dto to entity
                var equipment = _mapper.Map<Equipment>(model);
                //Call the update method
                await _dataAccess.UpdateAsync(equipment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }
    }
}
