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

        public async Task<Result> AddTestToInterviewAsync(TestsToInterviews testsToInterviews)
        {
            try
            {
                testsToInterviews.UserScore = 0;
                var result = await _context.TestsToInterviews.AddAsync(testsToInterviews).ConfigureAwait(true);
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return Result.Success(result);
            }
            catch (Exception e)
            {
                return Result.Failure<TestsToInterviews>("Exception: " + e.Message);
            }
        }

        public async Task<Result<IQueryable<Interview>>> GetAllAsync()
        {
            try
            {
                var result = await _context.Interviews.ToListAsync().ConfigureAwait(true);
                return Result.Success(result.AsQueryable());
            }
            catch(Exception e)
            {
                return Result.Failure<IQueryable<Interview>>("Exception: " + e.Message);
            }
        }

        public async Task<Result<Interview>> GetByApplicationIdAsync(Guid id)
        {
            try
            {
                var result = await _context.Interviews.Where(t => t.ApplicationId == id).SingleOrDefaultAsync().ConfigureAwait(true);
                if (result != default(Interview))
                    return Result.Success(result);
                return Result.Failure<Interview>("Exception: Interview not found");
            }
            catch (Exception e)
            {
                return Result.Failure<Interview>("Exception: " + e.Message);
            }
        }

        public async Task<Result<Interview>> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _context.Interviews.Where(t => t.InterviewId == id).SingleOrDefaultAsync().ConfigureAwait(true);
                if (result != default(Interview))
                    return Result.Success(result);
                return Result.Failure<Interview>("Exception: Interview not found");
            }
            catch(Exception e)
            {
                return Result.Failure<Interview>("Exception: " + e.Message);
            }
        }

        public async Task<Result<Interview>> GetByPersonIdAsync(Guid id)
        {
            try
            {
                var result = await _context.Interviews.Where(t => t.PersonId == id).SingleOrDefaultAsync().ConfigureAwait(true);
                if (result != default(Interview))
                    return Result.Success(result);
                return Result.Failure<Interview>("Exception: Interview not found");
            }
            catch (Exception e)
            {
                return Result.Failure<Interview>("Exception: " + e.Message);
            }
        }

        public async Task<Result> UpdateAsync(Guid id, Interview interview)
        {
            try
            {
                var interviewToUpdate = await _context.Interviews.SingleOrDefaultAsync(p => p.InterviewId == id).ConfigureAwait(true);

                interviewToUpdate.Date = interview.Date;
                interviewToUpdate.Details = interview.Details;
                interviewToUpdate.DurationHours = interview.DurationHours;
                interviewToUpdate.DurationMinutes = interview.DurationMinutes;

                await _context.SaveChangesAsync().ConfigureAwait(true);
                return Result.Success();
            }
            catch (Exception e)
            {
                return Result.Failure("Exception: " + e.Message);
            }
        }

        public async Task<Result<Person>> GetApplicantByIdAsync(Guid id)
        {
            try
            {
                var result = await _context.Persons.SingleOrDefaultAsync(p => p.PersonId == id).ConfigureAwait(true);
                if (result != default(Person))
                    return Result.Success(result);
                return Result.Failure<Person>("Exception: Person not found!");

            }
            catch (Exception e)
            {
                return Result.Failure<Person>("Exception: " + e.Message);
            }
        }

    }
}
