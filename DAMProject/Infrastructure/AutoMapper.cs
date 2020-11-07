using AutoMapper;
using Entities;
using Models.Person;

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
            });

            return configuration;
        }
    }
}
