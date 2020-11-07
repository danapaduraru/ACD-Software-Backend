using CSharpFunctionalExtensions;
using Database;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace Repositories.Implementations
{
    public class QuestionsRepository : IQuestionsRepository
    {
        private readonly Context _context;

        public QuestionsRepository(Context context)
        {
            _context = context;
        }

        public async Task<Result> AddAsync(Question question)
        {
            try
            {
                var result = await _context.Questions.AddAsync(question).ConfigureAwait(true);
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return Result.Success(result);
            }
            catch (Exception e)
            {
                return Result.Failure("Exception: " + e.Message);
            }
        }

        public async Task<Result<IQueryable<Question>>> GetAllAsync()
        {
            try
            {
                var result = await _context.Questions.Where(question => question.Cancelled == false).ToListAsync().ConfigureAwait(true);
               
                return Result.Success(result.AsQueryable());
            }
            catch (Exception e)
            {
                return Result.Failure<IQueryable<Question>>("Exception: " + e.Message);
            }
        }

        public async Task<Result<Question>> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _context.Questions.Where(question => question.Cancelled == false && question.QuestionId == id).SingleOrDefaultAsync();
                if(result != default(Question))
                    return Result.Success(result);
                return Result.Failure<Question>("Exception: " + "Question not found");
            }
            catch (Exception e)
            {
                return Result.Failure<Question>("Exception: " + e.Message);
            }
        }
    }
}
