using AutoMapper;
using CSharpFunctionalExtensions;
using Entities;
using Models.Interview;
using Repositories.Interfaces;
using Services.Interfaces;
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
    }
}
