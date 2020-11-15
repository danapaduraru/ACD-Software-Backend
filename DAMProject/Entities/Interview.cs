using Entities.EntityHelper.RelationshipEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Interview
    {
        public Guid InterviewId { get; set; }
        public DateTime Date { get; set; }
        public string Details { get; set; }
        public int DurationMinutes { get; set; }
        public int DurationHours { get; set; }

        [ForeignKey("PersonFK")]
        public Guid PersonId { get; set; }
        public Person Person { get; set; }

        [ForeignKey("ApplicationFK")]
        public Guid ApplicationId { get; set; }
        public Application Application { get; set; }

        public ICollection<TestsToInterviews> TestsToInterviews { get; set; }
        public ICollection<QuestionResponse> QuestionResponses { get; set; }
    }
}
