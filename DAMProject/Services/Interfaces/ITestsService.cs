using CSharpFunctionalExtensions;
using Models.Test;
using Models.Question;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Models.ModelHelpers;

namespace Services.Interfaces
{
    public interface ITestsService
    {
        Task<Result> AddAsync(AddTestDTO test);
        Task<Result<IEnumerable<TestDTO>>> GetAllAsync();
        Task<Result<TestDTO>> GetByIdAsync(Guid id);
        Task<Result> AddQuestionToTestAsync(TestToQuestionsRelationDTO TQRelDTO);
        
    }
}
