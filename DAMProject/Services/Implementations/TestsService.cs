using AutoMapper;
using CSharpFunctionalExtensions;
using Entities;
using Models.Question;
using Models.Test;
using Models.ModelHelpers;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class TestsService : ITestsService
    {
        private readonly ITestsRepository _testRepository;
        private readonly IMapper _mapper;

        public TestsService(ITestsRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public Task<Result> AddAsync(AddTestDTO addTestDTO)
        {
            var model = _mapper.Map<Test>(addTestDTO);
            return _testRepository.AddAsync(model);
        }

        public Task<Result> AddQuestionToTestAsync(TestToQuestionsRelationDTO TQRelDTO)
        {
            var modelTest = _mapper.Map<TestToQuestions>(TQRelDTO);
            return _testRepository.AddQuestionToTestAsync(modelTest);
        }

        public Task<Result<IEnumerable<TestDTO>>> GetAllAsync()
        {
            return _testRepository.GetAllAsync().Map(list => _mapper.Map<IEnumerable<TestDTO>>(list));
        }

        public Task<Result<TestDTO>> GetByIdAsync(Guid id)
        {

            return _testRepository.GetByIdAsync(id).Map(item => _mapper.Map<TestDTO>(item));
        }
    }
}
