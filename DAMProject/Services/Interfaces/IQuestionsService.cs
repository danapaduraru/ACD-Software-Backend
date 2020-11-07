using CSharpFunctionalExtensions;
using Models.Question;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IQuestionsService
    {
        Task<Result> AddAsync(AddQuestionDTO questionDTO);      
        Task<Result<IEnumerable<QuestionDTO>>> GetAllAsync();
        Task<Result<QuestionDTO>> GetByIdAsync(Guid id);

    }
}
