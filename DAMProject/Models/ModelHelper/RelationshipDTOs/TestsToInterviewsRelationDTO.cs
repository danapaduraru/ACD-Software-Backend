using System;

namespace Models.ModelHelper.RelationshipDTOs
{
    public class TestsToInterviewsRelationDTO
    {
        public Guid TestId { get; set; }
        public Guid InterviewId { get; set; }
        public double UserScore { get; set; }
    }
}
