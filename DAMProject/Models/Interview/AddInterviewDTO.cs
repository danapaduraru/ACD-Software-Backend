using System;

namespace Models.Interview
{
    public class AddInterviewDTO
    {
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public int DurationMinutes { get; set; }
        public int DurationHours { get; set; }
        public Guid PersonId { get; set; }
        public Guid ApplicationId { get; set; }
    }
}
