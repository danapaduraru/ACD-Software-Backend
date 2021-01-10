using CSharpFunctionalExtensions;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IApplicationsRepository
    {
        Task<Result<IQueryable<Application>>> GetAllAsync();
        Task<Result<IQueryable<Application>>> GetAllByJobIdAsync(Guid id);
        Task<Result<IQueryable<Application>>> GetAllByApplicantIdAsync(Guid id);
        Task<Result<Application>> GetByIdAsync(Guid id);
        Task<Result> AddAsync(Application application);
        Task<Result> UpdateAsync(Guid id, Application application);
        Task<Result<JobPosition>> GetJobPositionByIdAsync(Guid id);
        Task<Result<Person>> GetApplicantByIdAsync(Guid id);
    }
}
