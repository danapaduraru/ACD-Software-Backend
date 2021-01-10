using System;

namespace Models.Interview
{
    public class InterviewDTO: AddInterviewDTO
    {
        public Guid InterviewId { get; set; }
        public string ApplicantFirstName { get; set; }
        public string ApplicantLastName { get; set; }
    }
}
