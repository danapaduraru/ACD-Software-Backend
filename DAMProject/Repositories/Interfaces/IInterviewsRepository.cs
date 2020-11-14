using CSharpFunctionalExtensions;
using Entities;
using Entities.EntityHelper.RelationshipEntities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IInterviewsRepository
    {
        Task<Result<IQueryable<Interview>>> GetAllAsync();
        Task<Result<Interview>> GetByIdAsync(Guid id);
        Task<Result<Interview>> GetByPersonIdAsync(Guid id);
        Task<Result<Interview>> GetByApplicationIdAsync(Guid id);
        Task<Result> AddAsync(Interview interview);
        Task<Result> AddTestToInterviewAsync(TestsToInterviews testsToInterviews);
        Task<Result> UpdateAsync(Guid id, Interview interview);
    }
}
