using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.EntityHelper.RelationshipEntities
{
    public class TestsToInterviews
    {
        public Guid TestsToInterviewsId { get; set; }

        [ForeignKey("TestFK")]
        public Guid TestId { get; set; }
        public Test Test { get; set; }

        [ForeignKey("InterviewFK")]
        public Guid InterviewId { get; set; }
        public Interview Interview { get; set; }
    }
}
