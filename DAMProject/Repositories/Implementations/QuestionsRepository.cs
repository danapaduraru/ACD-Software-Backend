using CSharpFunctionalExtensions;
using Database;
using Entities;
using Repositories.Interfaces;
using System;
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
    }
}
