using CSharpFunctionalExtensions;
using Entities;
using Entities.EntityHelper.RelationshipEntities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ITestsRepository
    {
        Task<Result> AddAsync(Test test);
        Task<Result<IQueryable<Test>>> GetAllAsync();
        Task<Result<Test>> GetByIdAsync(Guid id);
        Task<Result> AddQuestionToTestAsync(TestsToQuestions testToQuestions);
    }
}
