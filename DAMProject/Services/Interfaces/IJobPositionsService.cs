using CSharpFunctionalExtensions;
using Models.JobPosition;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IJobPositionsService
    {
        Task<Result<IEnumerable<JobPositionDTO>>> GetAllAsync();
        Task<Result<JobPositionDTO>> GetByIdAsync(Guid id);
        Task<Result> AddAsync(AddJobPositionDTO personDTO);
        Task<Result> DeleteAsync(Guid id);
        Task<Result> UpdateAsync(Guid id, AddJobPositionDTO person);
    }
}
