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

        [ForeignKey("PersonFK")]
        public Guid PersonId { get; set; }
        public Person Person { get; set; }

        //public Guid ApplicationId { get; set; }

        //public Application Application { get; set; }

        public ICollection<TestsToInterviews> TestsToInterviews { get; set; }
    }
}
