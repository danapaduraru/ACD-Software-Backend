using System;

namespace Models.Interview
{
    public class UpdateInterviewDTO
    {
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public int DurationMinutes { get; set; }
        public int DurationHours { get; set; }
    }
}
