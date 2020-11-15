using CSharpFunctionalExtensions;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IQuestionResponsesRepository
    {
        Task<Result> AddAsync(QuestionResponse question);
        Task<Result<IQueryable<QuestionResponse>>> GetAllAsync();
        Task<Result<QuestionResponse>> GetByIdAsync(Guid id);
        Task<Result<IQueryable<QuestionResponse>>> GetAllResponsesForSpecificTestAsync(Guid interviewId, Guid testId);
        Task<Result<QuestionResponse>> GetResponseForQuestionAsync(Guid interviewId, Guid testId, Guid questionID);
    }
}
