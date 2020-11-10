using System;

namespace Models.Person
{
    public class PersonDTO: AddPersonDTO
    {
        public Guid PersonId { get; set; }
    }
}
