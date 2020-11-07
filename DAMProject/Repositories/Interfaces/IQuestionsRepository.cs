using CSharpFunctionalExtensions;
using Entities;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IQuestionsRepository
    {
        Task<Result> AddAsync(Question question);
    }
}
