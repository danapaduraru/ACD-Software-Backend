using AutoMapper;
using CSharpFunctionalExtensions;
using Entities;
using Models.Person;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
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

        public Task<Result<IEnumerable<PersonDTO>>> GetAllAsync()
        {
            return _personsRepository.GetAllAsync()
                .Map(list => _mapper.Map<IEnumerable<PersonDTO>>(list));
        }
        public Task<Result<PersonDTO>> GetByIdAsync(Guid id)
        {
            return _personsRepository.GetByIdAsync(id)
                .Map(item => _mapper.Map<PersonDTO>(item));
        }

        public Task<Result> AddAsync(AddPersonDTO addPersonDTO)
        {
            var model = _mapper.Map<Person>(addPersonDTO);
            return _personsRepository.AddAsync(model);
        }

        public Task<Result> DeleteAsync(Guid id)
        {
            return _personsRepository.DeleteAsync(id);
        }

        public Task<Result> UpdateAsync(Guid id, AddPersonDTO person)
        {
            var entity = _mapper.Map<Person>(person);
            return _personsRepository.UpdateAsync(id, entity);
        }

        public Task<Result<PersonDTO>> LoginAsync(LoginDTO loginDTO)
        {
            var personToLogin = _mapper.Map<Person>(loginDTO);
            return _personsRepository.LoginAsync(personToLogin)
                .Map(item => _mapper.Map<PersonDTO>(item));
        }
    }
}
