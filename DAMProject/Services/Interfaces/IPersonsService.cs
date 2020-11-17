using CSharpFunctionalExtensions;
using Models.Person;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPersonsService
    {
        Task<Result<IEnumerable<PersonDTO>>> GetAllAsync();
        Task<Result<PersonDTO>> GetByIdAsync(Guid id);
        Task<Result> AddAsync(AddPersonDTO personDTO);
        Task<Result> DeleteAsync(Guid id);
        Task<Result> UpdateAsync(Guid id, AddPersonDTO person);
        Task<Result<PersonDTO>> LoginAsync(LoginDTO loginDTO);
    }
}
