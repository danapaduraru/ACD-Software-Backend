using AutoMapper;
using CSharpFunctionalExtensions;
using Entities;
using Entities.EntityHelper.RelationshipEntities;
using Models.Interview;
using Models.ModelHelper.RelationshipDTOs;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class InterviewsService : IInterviewsService
    {
        private readonly IInterviewsRepository _interviewsRepository;
        private readonly IMapper _mapper;

        public InterviewsService(IInterviewsRepository interviewsRepository, IMapper mapper)
        {
            _interviewsRepository = interviewsRepository;
            _mapper = mapper;
        }

        public Task<Result> AddAsync(AddInterviewDTO addInterviewDTO)
        {
            var model = _mapper.Map<Interview>(addInterviewDTO);
            return _interviewsRepository.AddAsync(model);
        }

        public Task<Result> AddTestToInterviewAsync(TestsToInterviewsRelationDTO TIRelDTO)
        {
            var model = _mapper.Map<TestsToInterviews>(TIRelDTO);
            return _interviewsRepository.AddTestToInterviewAsync(model);
        }

        public Task<Result<IEnumerable<InterviewDTO>>> GetAllAsync()
        {
            return _interviewsRepository.GetAllAsync()
                .Map(list => _mapper.Map<IEnumerable<InterviewDTO>>(list));
        }

        public Task<Result<InterviewDTO>> GetByApplicationIdAsync(Guid id)
        {
            return _interviewsRepository.GetByApplicationIdAsync(id)
                .Map(item => _mapper.Map<InterviewDTO>(item));
        }

        public Task<Result<InterviewDTO>> GetByIdAsync(Guid id)
        {
            return _interviewsRepository.GetByIdAsync(id)
                .Map(item => _mapper.Map<InterviewDTO>(item));
        }

        public Task<Result<InterviewDTO>> GetByPersonIdAsync(Guid id)
        {
            return _interviewsRepository.GetByPersonIdAsync(id)
                .Map(item => _mapper.Map<InterviewDTO>(item));
        }

        public Task<Result> UpdateAsync(Guid id, UpdateInterviewDTO updateInterviewDTO)
        {
            var entity = _mapper.Map<Interview>(updateInterviewDTO);
            return _interviewsRepository.UpdateAsync(id, entity);
        }
    }
}
