using AutoMapper;
using CSharpFunctionalExtensions;
using Entities;
using Models.Question;
using Repositories.Interfaces;
using Services.Interfaces;
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
    }
}
