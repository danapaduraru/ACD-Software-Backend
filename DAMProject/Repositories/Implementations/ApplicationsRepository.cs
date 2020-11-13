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
    public class ApplicationsRepository: IApplicationsRepository
    {
        private readonly Context _context;

        public ApplicationsRepository(Context context)
        {
            _context = context;
        }

        public async Task<Result<IQueryable<Application>>> GetAllAsync()
        {
            try
            {
                var result = await _context.Applications.ToListAsync().ConfigureAwait(true);
                return Result.Success(result.AsQueryable());
            }
            catch (Exception e)
            {
                return Result.Failure<IQueryable<Application>>("Exception: " + e.Message);
            }
        }

        public async Task<Result<Application>> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _context.Applications.SingleOrDefaultAsync(p => p.ApplicationId == id).ConfigureAwait(true);
                return Result.Success(result);

            }
            catch (Exception e)
            {
                return Result.Failure<Application>("Exception: " + e.Message);
            }
        }

        public async Task<Result> AddAsync(Application application)
        {
            try
            {
                application.ApplicationDate = DateTime.Now;
                application.FeedbackText = "No feedback yet";
                application.FeedbackType = Helper.FeedbackType.None;
                application.Status = Helper.ApplicationStatus.Pending;

                var result = await _context.Applications.AddAsync(application).ConfigureAwait(true);
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return Result.Success(result);
            }
            catch (Exception e)
            {
                return Result.Failure("Exception: " + e.Message);
            }
        }

        public async Task<Result> UpdateAsync(Guid id, Application application)
        {
            try
            {
                var applicationToUpdate = await _context.Applications.SingleOrDefaultAsync(p => p.ApplicationId == id).ConfigureAwait(true);

                applicationToUpdate.Status = application.Status;
                applicationToUpdate.FeedbackType = application.FeedbackType;
                applicationToUpdate.FeedbackText = application.FeedbackText;

                await _context.SaveChangesAsync().ConfigureAwait(true);
                return Result.Success();
            }
            catch (Exception e)
            {
                return Result.Failure("Exception: " + e.Message);
            }
        }

        public async Task<Result<IQueryable<Application>>> GetAllByJobIdAsync(Guid id)
        {
            try
            {
                var result = await _context.Applications.Where(a => a.JobPositionId == id).ToListAsync().ConfigureAwait(true);
                return Result.Success(result.AsQueryable());
            }
            catch (Exception e)
            {
                return Result.Failure<IQueryable<Application>>("Exception: " + e.Message);
            }
        }

        public async Task<Result<IQueryable<Application>>> GetAllByApplicantIdAsync(Guid id)
        {
            try
            {
                var result = await _context.Applications.Where(a => a.ApplicantId == id).ToListAsync().ConfigureAwait(true);
                return Result.Success(result.AsQueryable());
            }
            catch (Exception e)
            {
                return Result.Failure<IQueryable<Application>>("Exception: " + e.Message);
            }
        }
    }
}
