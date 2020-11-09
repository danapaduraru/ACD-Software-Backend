using AutoMapper;
using CSharpFunctionalExtensions;
using Entities;
using Models.JobPosition;
using Models.Person;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Services.Implementations
{
    public class JobPositionsService: IJobPositionsService
    {
        private readonly IJobPositionsRepository _jobPositionsRepository;
        private readonly IMapper _mapper;

        public JobPositionsService(IJobPositionsRepository jobPositionsRepository, IMapper mapper)
        {
            _jobPositionsRepository = jobPositionsRepository;
            _mapper = mapper;
        }

        public Task<Result<IEnumerable<JobPositionDTO>>> GetAllAsync()
        {
            return _jobPositionsRepository.GetAllAsync()
                .Map(list => _mapper.Map<IEnumerable<JobPositionDTO>>(list));
        }
        public Task<Result<JobPositionDTO>> GetByIdAsync(Guid id)
        {
            return _jobPositionsRepository.GetByIdAsync(id)
                .Map(item => _mapper.Map<JobPositionDTO>(item));
        }

        public Task<Result> AddAsync(AddJobPositionDTO addJobPositionDTO)
        {
            var model = _mapper.Map<JobPosition>(addJobPositionDTO);
            return _jobPositionsRepository.AddAsync(model);
        }

        public Task<Result> DeleteAsync(Guid id)
        {
            return _jobPositionsRepository.DeleteAsync(id);
        }

        public Task<Result> UpdateAsync(Guid id, AddJobPositionDTO addJobPositionDTO)
        {
            var entity = _mapper.Map<JobPosition>(addJobPositionDTO);
            return _jobPositionsRepository.UpdateAsync(id, entity);
        }
    }
}
