using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyInventory.API.ViewModels;
using MyInventory.Application.Abstract;
using MyInventory.Application.DTO.EquipmentDtos;
using MyInventory.Application.DTO.EquipmentImageDtos;

namespace MyInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController : ControllerBase
    {
        //Inject EquipmentService and EquipmentImageService
        private readonly IEquipmentService _equipmentService;
        private readonly IEquipmentImageService _equipmentImageService;

        public EquipmentController(IEquipmentService equipmentService, IEquipmentImageService equipmentImageService)
        {
            _equipmentService = equipmentService;
            _equipmentImageService = equipmentImageService;
        }

        [HttpGet]
        //Use [FromQuery] to accept query parameters
        public async Task<IActionResult> Get([FromQuery] EquipmentQueryViewModel query)
        {
            try
            {
                //Step 1: Retrieve paged equipments
                var equipments = await _equipmentService.GetPagedEquipments(query.Page, query.PageSize, query.CategoryId, query.LocationId, query.SearchQuery);
                //Return OK
                return Ok(equipments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving equipments.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                //Step 1: Retrieve an equipment by id
               
                var equipment = await _equipmentService.Get(id);
                //Step 2: Check if equipment is null
                if (equipment == null)
                {
                    //Return NotFound
                    return NotFound();
                }
                //Return OK
                return Ok(equipment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving an equipment.", error = ex.Message });
            }
        }

        [HttpPost]
        //Use [FromForm] to accept form data
        public async Task<IActionResult> Create([FromForm] CreateEquipmetDto data, List<IFormFile> images)
        {
            try
            {
                //Step 1: Insert Equipment via EquipmentService
                var equipment = await _equipmentService.Insert(data);
                //Step 2: Upload each image to the server and insert the image path to the database
                foreach (var image in images)
                {
                    var equipmentImage = await _equipmentImageService.UploadImage(image, equipment.EquipmentId);
                    await _equipmentImageService.Insert(equipmentImage);
                }
                //Return OK
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while inserting an equipment.", error = ex.Message });
            }
        }
        
        [HttpPut]
        //Use [FromForm] to accept form data
        public async Task<IActionResult> Update([FromForm] UpdateEquipmentDto data, List<IFormFile> images)
        {
            try
            {
                //Step 1: Update Equipment via EquipmentService
                await _equipmentService.Update(data);

                //Step 2: Delete matching images of the equipment
                if (data.EquipmentImageIds != null)
                {
                    var equipmentImages = await _equipmentImageService.Get(data.EquipmentImageIds);
                    await _equipmentImageService.BulkDelete(equipmentImages);
                }


                if (images != null)
                {
                    //Step 3: Upload each image to the server and insert the image path to the database
                    foreach (var image in images)
                    {
                        var equipmentImage = await _equipmentImageService.UploadImage(image, data.EquipmentId);
                        await _equipmentImageService.Insert(equipmentImage);
                    }
                }


                //Return OK
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating an equipment.", error = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(List<int> idList)
        {
            try
            {
                //Step 1: Retrieve all equipments by idList
                var equipments = await _equipmentService.Get(idList);
                //Step 2: Delete all equipments
                await _equipmentService.BulkDelete(equipments);
                //Return OK
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting an equipment.", error = ex.Message });
            }
        }
    }
}
