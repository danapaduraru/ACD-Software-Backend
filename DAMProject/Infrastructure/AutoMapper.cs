using AutoMapper;
using Entities;
using Models.ModelHelpers;
using Models.Person;
using Models.Question;
using Models.Test;
namespace DAMInfrastructure
{
    public static class AutoMapper
    {
        public static MapperConfiguration Configure()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<AddPersonDTO, Person>();
                config.CreateMap<Person, PersonDTO>();
                
                config.CreateMap<AddQuestionDTO, Question>();
                config.CreateMap<Question, QuestionDTO>();

                config.CreateMap<AddTestDTO, Test>();
                config.CreateMap<Test, TestDTO>();

                config.CreateMap<TestToQuestionsRelationDTO, TestToQuestions>();
            });

            return configuration;
        }
    }
}
