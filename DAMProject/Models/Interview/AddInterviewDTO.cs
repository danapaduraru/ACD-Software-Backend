using System;

namespace Models.Interview
{
    public class AddInterviewDTO
    {
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public Guid PersonId { get; set; }
    }
}
