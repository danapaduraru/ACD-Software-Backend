using CSharpFunctionalExtensions;
using Models.Question;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IQuestionsService
    {
        Task<Result> AddAsync(AddQuestionDTO questionDTO);
    }
}
