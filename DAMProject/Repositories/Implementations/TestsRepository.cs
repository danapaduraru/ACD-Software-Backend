using CSharpFunctionalExtensions;
using Database;
using Entities;
using Entities.EntityHelper.RelationshipEntities;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace Repositories.Implementations
{
    public class TestsRepository: ITestsRepository
    {
        private readonly Context _context;

        public TestsRepository(Context context)
        {
            _context = context;
        }

        public async Task<Result> AddAsync(Test test)
        {
            try
            {
                var result = await _context.Tests.AddAsync(test).ConfigureAwait(true);
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return Result.Success(result);
            }
            catch (Exception e)
            {
                return Result.Failure("Exception: " + e.Message);
            }
        }

        public async Task<Result<IQueryable<Test>>> GetAllAsync()
        {
            try
            {
                var result = await _context.Tests.ToListAsync().ConfigureAwait(true);

                return Result.Success(result.AsQueryable());
            }
            catch (Exception e)
            {
                return Result.Failure<IQueryable<Test>>("Exception: " + e.Message);
            }
        }

        public async Task<Result<Test>> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _context.Tests.Where(test => test.TestId == id).SingleOrDefaultAsync();
                if (result != default(Test))
                    return Result.Success(result);
                return Result.Failure<Test>("Exception: " + "Test not found");
            }
            catch (Exception e)
            {
                return Result.Failure<Test>("Exception: " + e.Message);
            }
        }

        public async Task<Result> AddQuestionToTestAsync(TestsToQuestions testToQuestions)
        {

            try
            {
                var result = await _context.TestsToQuestions.AddAsync(testToQuestions).ConfigureAwait(true);
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return Result.Success(result);
            }
            catch (Exception e)
            {
                return Result.Failure<TestsToQuestions>("Exception: " + e.Message);
            }
        }

        
    }
}
