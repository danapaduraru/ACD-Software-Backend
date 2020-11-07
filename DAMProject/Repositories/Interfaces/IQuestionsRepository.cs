using CSharpFunctionalExtensions;
using Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IQuestionsRepository
    {
        Task<Result> AddAsync(Question question);
        Task<Result<IQueryable<Question>>> GetAllAsync();
        Task<Result<Question>> GetByIdAsync(Guid id);
    }
}
