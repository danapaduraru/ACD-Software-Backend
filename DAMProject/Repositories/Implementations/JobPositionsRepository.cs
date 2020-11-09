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
    public class JobPositionsRepository: IJobPositionsRepository
    {
        private readonly Context _context;

        public JobPositionsRepository(Context context)
        {
            _context = context;
        }

        public async Task<Result<IQueryable<JobPosition>>> GetAllAsync()
        {
            try
            {
                var result = await _context.JobPositions.ToListAsync().ConfigureAwait(true);
                return Result.Success(result.AsQueryable());
            }
            catch (Exception e)
            {
                return Result.Failure<IQueryable<JobPosition>>("Exception: " + e.Message);
            }
        }

        public async Task<Result<JobPosition>> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _context.JobPositions.SingleOrDefaultAsync(p => p.JobPositionId == id).ConfigureAwait(true);
                return Result.Success(result);

            }
            catch (Exception e)
            {
                return Result.Failure<JobPosition>("Exception: " + e.Message);
            }
        }

        public async Task<Result> AddAsync(JobPosition position)
        {
            try
            {
                var result = await _context.JobPositions.AddAsync(position).ConfigureAwait(true);
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return Result.Success(result);
            }
            catch (Exception e)
            {
                return Result.Failure("Exception: " + e.Message);
            }
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            try
            {
                var position = await _context.JobPositions.SingleOrDefaultAsync(p => p.JobPositionId == id).ConfigureAwait(true);
                _context.Remove(position);
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return Result.Success();
            }
            catch (Exception e)
            {
                return Result.Failure("Exception: " + e.Message);
            }
        }

        public async Task<Result> UpdateAsync(Guid id, JobPosition position)
        {
            try
            {
                var positionToUpdate = await _context.JobPositions.SingleOrDefaultAsync(p => p.JobPositionId == id).ConfigureAwait(true);

                positionToUpdate.Position = position.Position;
                positionToUpdate.Level = position.Level;
                positionToUpdate.StartDate = position.StartDate;
                positionToUpdate.Status = position.Status;
                positionToUpdate.Description = position.Description;
                positionToUpdate.ApplicationDeadline = position.ApplicationDeadline;

                await _context.SaveChangesAsync().ConfigureAwait(true);
                return Result.Success();
            }
            catch (Exception e)
            {
                return Result.Failure("Exception: " + e.Message);
            }
        }
    }
}
