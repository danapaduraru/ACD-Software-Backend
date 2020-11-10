using System;

namespace Entities
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Helper.PersonType PersonType { get; set; }
        public string Position { get; set; }
        public string LinkCV { get; set; }
    }
}
