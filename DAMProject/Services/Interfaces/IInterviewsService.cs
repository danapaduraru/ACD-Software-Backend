using CSharpFunctionalExtensions;
using Models.Interview;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IInterviewsService
    {
        Task<Result> AddAsync(AddInterviewDTO addInterviewDTO);
    }
}
