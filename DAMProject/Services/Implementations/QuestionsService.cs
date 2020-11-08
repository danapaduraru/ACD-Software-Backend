using AutoMapper;
using CSharpFunctionalExtensions;
using Entities;
using Models.Question;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Services.Implementations
{
    public class QuestionsService : IQuestionsService
    {
        private readonly IQuestionsRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionsService(IQuestionsRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }
        
        public Task<Result> AddAsync(AddQuestionDTO addQuestionDTO)
        {
            var model = _mapper.Map<Question>(addQuestionDTO);
            return _questionRepository.AddAsync(model);
        }

        public Task<Result<IEnumerable<QuestionDTO>>> GetAllAsync()
        {
            return _questionRepository.GetAllAsync().Map(list => _mapper.Map<IEnumerable<QuestionDTO>>(list));
        }

        public Task<Result<QuestionDTO>> GetByIdAsync(Guid id)
        {

            return _questionRepository.GetByIdAsync(id).Map(item => _mapper.Map<QuestionDTO>(item));
        }

        public Task<Result<IEnumerable<QuestionDTO>>> GetQuestionsFromTestAsync(Guid testId)
        {
            return _questionRepository.GetQuestionsFromTestAsync(testId).Map(list => _mapper.Map<IEnumerable<QuestionDTO>>(list));
        }
    }
}
