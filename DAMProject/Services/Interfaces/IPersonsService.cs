using CSharpFunctionalExtensions;
using Models.Person;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPersonsService
    {
        Task<Result> AddAsync(AddPersonDTO personDTO);
    }
}
