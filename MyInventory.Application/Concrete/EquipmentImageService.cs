using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyInventory.Application.Abstract;
using MyInventory.Application.DTO.EquipmentDtos;
using MyInventory.Application.DTO.EquipmentImageDtos;
using MyInventory.Application.DTO.ImgbbDtos;
using MyInventory.Domain.Entities;
using MyInventory.Infrastructure.Configurations;
using MyInventory.Persistence.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyInventory.Application.Concrete
{
    public class EquipmentImageService : IEquipmentImageService
    {
        private readonly IEquipmentImageDataAccess _dataAccess;
        private readonly IMapper _mapper;
        private readonly ImgBBSettings _settings;

        public EquipmentImageService(IEquipmentImageDataAccess dataAccess, IMapper mapper, IOptions<ImgBBSettings> settings)
        {
            _dataAccess = dataAccess;
            _mapper = mapper;
            _settings = settings.Value;
        }

        public async Task BulkDelete(List<EquipmentImageDto> modelList)
        {
            try
            {
                //Map the dto list to entity list
                var equipmentImages = _mapper.Map<List<EquipmentImage>>(modelList);
                //Call the bulk delete method
                await _dataAccess.BulkDeleteAsync(equipmentImages);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public async Task Delete(EquipmentImageDto model)
        {
            try
            {
                //Map the dto to entity
                var equipmentImage = _mapper.Map<EquipmentImage>(model);
                //Call the delete method
                await _dataAccess.DeleteAsync(equipmentImage);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public async Task<EquipmentImageDto> Get(int id)
        {
            try
            {
                //Call the get method and map the entity to dto
                var equipmentImage = _mapper.Map<EquipmentImageDto>(await _dataAccess.GetAsync(id));
                //Return the dto
                return equipmentImage;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public async Task<List<EquipmentImageDto>> Get()
        {
            try
            {
                //Call the get method and map the entity list to dto list
                var equipmentImages = _mapper.Map<List<EquipmentImageDto>>(await _dataAccess.GetAsync());
                //Return the dto list
                return equipmentImages;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public async Task<List<EquipmentImageDto>> Get(List<int> idList)
        {
            try
            {
                //Call the get method - fetch the entities by id list
                var equipmentImages = await _dataAccess.GetAsync(idList, "EquipmentImageId");
                //Map the entity list to dto list
                var equipmentImageDtos = _mapper.Map<List<EquipmentImageDto>>(equipmentImages);
                //Return the dto list
                return equipmentImageDtos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public async Task<EquipmentImageDto> Insert(CreateEquipmentImageDto model)
        {
            try
            {
                //Map the dto to entity
                var equipmentImage = _mapper.Map<EquipmentImage>(model);
                //Call the insert method
                await _dataAccess.InsertAsync(equipmentImage);
                //Map the entity to dto
                var equipmentImageDto = _mapper.Map<EquipmentImageDto>(equipmentImage);
                //Return the dto
                return equipmentImageDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public async Task Update(UpdateEquipmentImageDto model)
        {
            try
            {
                //Map the dto to entity
                var equipmentImage = _mapper.Map<EquipmentImage>(model);
                //Call the update method
                await _dataAccess.UpdateAsync(equipmentImage);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public async Task<CreateEquipmentImageDto> UploadImage(IFormFile file, int equipmentId)
        {
            //Check if the file is valid
            if (file == null || file.Length == 0)
                throw new ArgumentException("Invalid file.");

            using var memoryStream = new MemoryStream();
            //Copy the file to memory stream
            await file.CopyToAsync(memoryStream);

            //Create a form data content
            using var content = new MultipartFormDataContent();
            //Create a byte array content from memory stream
            var fileContent = new ByteArrayContent(memoryStream.ToArray());
            //Set the content type
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(file.ContentType);
            //Set the file name
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

            //Add the file content to the form data content
            content.Add(fileContent, "image", fileName);

            //Set the target url
            string targetUrl = $"{_settings.BaseUrl}?key={_settings.ApiKey}";

            //Create a http client
            using (HttpClient _httpClient = new HttpClient())
            {
                //Post the file to the target url
                var response = await _httpClient.PostAsync(targetUrl, content);

                //Check if the response is successful
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"File upload failed: {response.StatusCode}");

                //Read the response content
                var jsonString = await response.Content.ReadAsStringAsync();
                //Parse the json string
                using var jsonDoc = JsonDocument.Parse(jsonString);

                //Get the data property
                var data = jsonDoc.RootElement.GetProperty("data");
                //Get the url property
                var url = data.GetProperty("url").GetString();

                //Check if the url is null or empty
                if(url.IsNullOrEmpty())
                    throw new Exception("Image upload failed.");

                //Return the create equipment image dto
                return new CreateEquipmentImageDto
                {
                    Path = url,
                    EquipmentId = equipmentId
                };
            }

        }
    }
}
