using MyInventory.Application.Abstract;
using MyInventory.Domain.Entities;
using MyInventory.Persistence.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInventory.Application.Concrete
{
    public class LocationService : ILocationService
    {
        private readonly ILocationDataAccess _dataAccess;

        public LocationService(ILocationDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task TDelete(Location model)
        {
            try
            {
                await _dataAccess.Delete(model);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public async Task<Location> TGet(int id)
        {
            try
            {
                return await _dataAccess.Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public async Task<List<Location>> TGet()
        {
            try
            {
                return await _dataAccess.Get();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public async Task TInsert(Location model)
        {
            try
            {
                await _dataAccess.Insert(model);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }

        public async Task TUpdate(Location model)
        {
            try
            {
                await _dataAccess.Update(model);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error {ex.Message}");
            }
        }
    }
}
