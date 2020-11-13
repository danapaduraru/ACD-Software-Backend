using Entities.EntityHelper.RelationshipEntities;
using System;
using System.Collections.Generic;

namespace Entities
{
    public class Test
    {
        public Guid TestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HoursLimitTime { get; set; }
        public int MinutesLimitTime { get; set; }

        public ICollection<TestsToQuestions> TestToQuestions { get; set; }
        public virtual ICollection<TestsToInterviews> TestsToInterviews { get; set; }
    }
}
