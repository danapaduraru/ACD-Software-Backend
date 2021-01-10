using AutoMapper;
using CSharpFunctionalExtensions;
using Entities;
using Models.Application;
using Models.Person;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Services.Implementations
{
    public class ApplicationsService : IApplicationsService
    {
        private readonly IApplicationsRepository _personsRepository;
        private readonly IMapper _mapper;

        public ApplicationsService(IApplicationsRepository personsRepository, IMapper mapper)
        {
            _personsRepository = personsRepository;
            _mapper = mapper;
        }

        public Task<Result<IEnumerable<ApplicationDTO>>> GetAllAsync()
        {
            return _personsRepository.GetAllAsync()
                .Map(list => _mapper.Map<IEnumerable<ApplicationDTO>>(list));
        }
        public Task<Result<IEnumerable<ApplicationDTO>>> GetAllByJobIdAsync(Guid id)
        {
            var result = _personsRepository.GetAllByJobIdAsync(id)
                .Map(list => _mapper.Map<IEnumerable<ApplicationDTO>>(list));
            foreach (var value in result.Result.Value)
            {
                var applicant = _personsRepository.GetApplicantByIdAsync(value.ApplicantId).Result.Value;
                value.ApplicantFirstName = applicant.FirstName;
                value.ApplicantLastName = applicant.LastName;
            }
            return result;
        }

        public Task<Result<IEnumerable<ApplicationDTO>>> GetAllByApplicantIdAsync(Guid id)
        {
            var result = _personsRepository.GetAllByApplicantIdAsync(id)
                .Map(list => _mapper.Map<IEnumerable<ApplicationDTO>>(list));
            foreach(var value in result.Result.Value)
            {
                value.JobName = _personsRepository.GetJobPositionByIdAsync(value.JobPositionId).Result.Value.Position;
            }
            return result;
        }


        public Task<Result<ApplicationDTO>> GetByIdAsync(Guid id)
        {
            return _personsRepository.GetByIdAsync(id)
                .Map(item => _mapper.Map<ApplicationDTO>(item));
        }

        public Task<Result> AddAsync(AddApplicationDTO addApplicationDTO)
        {
            var model = _mapper.Map<Application>(addApplicationDTO);
            return _personsRepository.AddAsync(model);
        }

        public Task<Result> UpdateAsync(Guid id, UpdateApplicationDTO application)
        {
            var entity = _mapper.Map<Application>(application);
            return _personsRepository.UpdateAsync(id, entity);
        }
    }
}