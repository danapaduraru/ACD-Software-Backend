using CSharpFunctionalExtensions;
using Entities;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IPersonsRepository
    {
        Task<Result> AddAsync(Person person);
    }
}
