using CSharpFunctionalExtensions;
using Models.QuestionResponse;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IQuestionResponsesService
    {
        Task<Result> AddAsync(AddQuestionResponseDTO questionResponseDTO);
        Task<Result<IEnumerable<QuestionResponseDTO>>> GetAllAsync();
        Task<Result<QuestionResponseDTO>> GetByIdAsync(Guid id);
        Task<Result<IEnumerable<QuestionResponseDTO>>> GetAllResponsesForSpecificTestAsync(Guid interviewId, Guid testId);
        Task<Result<QuestionResponseDTO>> GetResponseForQuestionAsync(Guid interviewId, Guid testId, Guid questionID);

    }
}
