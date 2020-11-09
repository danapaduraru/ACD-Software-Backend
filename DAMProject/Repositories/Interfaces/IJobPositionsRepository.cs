using CSharpFunctionalExtensions;
using Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IJobPositionsRepository
    {
        Task<Result<IQueryable<JobPosition>>> GetAllAsync();
        Task<Result<JobPosition>> GetByIdAsync(Guid id);
        Task<Result> AddAsync(JobPosition person);
        Task<Result> DeleteAsync(Guid id);
        Task<Result> UpdateAsync(Guid id, JobPosition person);
    }
}
