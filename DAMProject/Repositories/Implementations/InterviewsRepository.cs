using CSharpFunctionalExtensions;
using Database;
using Entities;
using Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class InterviewsRepository : IInterviewsRepository
    {
        private readonly Context _context;

        public InterviewsRepository(Context context)
        {
            _context = context;
        }

        public async Task<Result> AddAsync(Interview interview)
        {
            try
            {
                var result = await _context.Interviews.AddAsync(interview).ConfigureAwait(true);
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return Result.Success(result);
            }
            catch(Exception e)
            {
                return Result.Failure("Exception: " + e.Message);
            }
        }
    }
}
