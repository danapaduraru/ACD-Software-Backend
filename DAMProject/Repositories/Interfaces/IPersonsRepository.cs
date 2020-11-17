using CSharpFunctionalExtensions;
using Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IPersonsRepository
    {
        Task<Result<IQueryable<Person>>> GetAllAsync();
        Task<Result<Person>> GetByIdAsync(Guid id);
        Task<Result> AddAsync(Person person);
        Task<Result> DeleteAsync(Guid id);
        Task<Result> UpdateAsync(Guid id, Person person);
        Task<Result<Person>> LoginAsync(Person person);
    }
}
