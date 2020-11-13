using CSharpFunctionalExtensions;
using Entities;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IInterviewsRepository
    {
        Task<Result> AddAsync(Interview interview);
    }
}
