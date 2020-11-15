using AutoMapper;
using Entities;
using Models.ModelHelper;
using Models.Person;
using Models.Question;
using Models.Test;
using Models.JobPosition;
using Entities.EntityHelper.RelationshipEntities;
using Models.Interview;
using Models.Application;
using Models.ModelHelper.RelationshipDTOs;
using Models.QuestionResponse;

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

                config.CreateMap<AddInterviewDTO, Interview>();
                config.CreateMap<Interview, InterviewDTO>();
                config.CreateMap<UpdateInterviewDTO, Interview>();

                config.CreateMap<AddApplicationDTO, Application>();
                config.CreateMap<UpdateApplicationDTO, Application>();
                config.CreateMap<Application, ApplicationDTO>();

                config.CreateMap<TestsToQuestionsRelationDTO, TestsToQuestions>();
                config.CreateMap<TestsToInterviewsRelationDTO, TestsToInterviews>();

                config.CreateMap<AddQuestionResponseDTO, QuestionResponse>();
                config.CreateMap<QuestionResponse, QuestionResponseDTO>();
            });

            return configuration;
        }
    }
}
