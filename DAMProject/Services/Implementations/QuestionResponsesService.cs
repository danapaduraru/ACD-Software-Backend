using Services.Interfaces;
using Models.QuestionResponse;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using System.Collections.Generic;
using System;
using Repositories.Interfaces;
using AutoMapper;
using Entities;

namespace Services.Implementations
{
    public class QuestionResponsesService : IQuestionResponsesService
    {
        private readonly IQuestionResponsesRepository _questionResponsesRepository;
        private readonly IMapper _mapper;

        public QuestionResponsesService(IQuestionResponsesRepository questionResponsesRepository, IMapper mapper)
        {
            _questionResponsesRepository = questionResponsesRepository;
            _mapper = mapper;
        }
        public Task<Result> AddAsync(AddQuestionResponseDTO questionResponseDTO)
        {
            var model = _mapper.Map<QuestionResponse>(questionResponseDTO);
            return _questionResponsesRepository.AddAsync(model);
        }

        public Task<Result<IEnumerable<QuestionResponseDTO>>> GetAllAsync()
        {
            return _questionResponsesRepository.GetAllAsync().Map(list => _mapper.Map<IEnumerable<QuestionResponseDTO>>(list));
        }

        public Task<Result<IEnumerable<QuestionResponseDTO>>> GetAllResponsesForSpecificTestAsync(Guid interviewId, Guid testId)
        {
            return _questionResponsesRepository.GetAllResponsesForSpecificTestAsync(interviewId, testId).Map(list => _mapper.Map<IEnumerable<QuestionResponseDTO>>(list));
        }

        public Task<Result<QuestionResponseDTO>> GetByIdAsync(Guid id)
        {
            return _questionResponsesRepository.GetByIdAsync(id).Map(item => _mapper.Map<QuestionResponseDTO>(item));
        }

        public Task<Result<QuestionResponseDTO>> GetResponseForQuestionAsync(Guid interviewId, Guid testId, Guid questionID)
        {
            return _questionResponsesRepository.GetResponseForQuestionAsync(interviewId, testId, questionID).Map(item => _mapper.Map<QuestionResponseDTO>(item));
        }
    }
}
