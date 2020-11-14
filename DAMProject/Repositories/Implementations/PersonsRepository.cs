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
    public class PersonsRepository : IPersonsRepository
    {
        private readonly Context _context;

        public PersonsRepository(Context context)
        {
            _context = context;
        }

        public async Task<Result<IQueryable<Person>>> GetAllAsync()
        {
            try
            {
                var result = await _context.Persons.ToListAsync().ConfigureAwait(true);
                return Result.Success(result.AsQueryable());
            }
            catch(Exception e)
            {
                return Result.Failure<IQueryable<Person>>("Exception: " + e.Message);
            }
        }

        public async Task<Result<Person>> GetByIdAsync(Guid id)
        {
            try
            {
                var result = await _context.Persons.SingleOrDefaultAsync(p => p.PersonId == id).ConfigureAwait(true);
                if (result != default(Person))
                    return Result.Success(result);
                return Result.Failure<Person>("Exception: Person not found!");
               
            }
            catch(Exception e)
            {
                return Result.Failure<Person>("Exception: " + e.Message);
            }
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

        public async Task<Result> DeleteAsync(Guid id)
        {
            try
            {
                var person = await _context.Persons.SingleOrDefaultAsync(p => p.PersonId == id).ConfigureAwait(true);
                _context.Remove(person);
                await _context.SaveChangesAsync().ConfigureAwait(true);
                return Result.Success();
            }
            catch(Exception e)
            {
                return Result.Failure("Exception: " + e.Message);
            }
        }

        public async Task<Result> UpdateAsync(Guid id, Person person)
        {
            try
            {
                var personToUpdate = await _context.Persons.SingleOrDefaultAsync(p => p.PersonId == id).ConfigureAwait(true);

                personToUpdate.FirstName = person.FirstName;
                personToUpdate.LastName = person.LastName;
                personToUpdate.PhoneNumber = person.PhoneNumber;
                personToUpdate.BirthDate = person.BirthDate;
                personToUpdate.Email = person.Email;
                personToUpdate.Password = person.Password;

                await _context.SaveChangesAsync().ConfigureAwait(true);
                return Result.Success();
            }
            catch(Exception e)
            {
                return Result.Failure("Exception: " + e.Message);
            }
        }
    }
}
