using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Person
{
    public class PersonDTO: AddPersonDTO
    {
        public Guid PersonId { get; set; }
    }
}
