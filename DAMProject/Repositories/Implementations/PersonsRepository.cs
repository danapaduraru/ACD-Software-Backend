using CSharpFunctionalExtensions;
using Database;
using Entities;
using Repositories.Interfaces;
using System;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class PersonsRepository : IPersonsRepository
    {
        private readonly Context _context;

        public PersonsRepository(Context context)
        {
            _context = context;
        }

        public async Task<Result> AddAsync(Person person)
        {
            try
            {
                var result = await _context.Persons.AddAsync(person).ConfigureAwait(true);
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
