using MyInventory.Application.Abstract;
using MyInventory.Domain.Entities;
using MyInventory.Persistence.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyInventory.Application.Concrete
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentDataAccess _dataAccess;

        public AssignmentService(IAssignmentDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task TDelete(Assignment model)
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

        public async Task<Assignment> TGet(int id)
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

        public async Task<List<Assignment>> TGet()
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

        public async Task TInsert(Assignment model)
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

        public async Task TUpdate(Assignment model)
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
