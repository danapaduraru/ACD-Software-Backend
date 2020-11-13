using AutoMapper;
using Entities;
using Models.ModelHelper;
using Models.Person;
using Models.Question;
using Models.Test;
using Models.JobPosition;
using Entities.EntityHelper.RelationshipEntities;
using Models.Interview;

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

                config.CreateMap<AddJobPositionDTO, JobPosition>();
                config.CreateMap<JobPosition, JobPositionDTO>();

                config.CreateMap<TestsToQuestionsRelationDTO, TestsToQuestions>();

                config.CreateMap<AddInterviewDTO, Interview>();
            });

            return configuration;
        }
    }
}
