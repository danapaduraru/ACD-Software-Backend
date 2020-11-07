using AutoMapper;
using CSharpFunctionalExtensions;
using Entities;
using Models;
using Repositories.Interfaces;
using Services.Interfaces;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class PersonsService : IPersonsService
    {
        private readonly IPersonsRepository _personsRepository;
        private readonly IMapper _mapper;

        public PersonsService(IPersonsRepository personsRepository, IMapper mapper)
        {
            _personsRepository = personsRepository;
            _mapper = mapper;
        }

        public Task<Result> AddAsync(AddPersonDTO addPersonDTO)
        {
            var model = _mapper.Map<Person>(addPersonDTO);
            return _personsRepository.AddAsync(model);
        }
    }
}
