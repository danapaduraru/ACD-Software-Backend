using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Application
    {
        public Guid ApplicationId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public Helper.ApplicationStatus Status { get; set; }
        public Helper.FeedbackType FeedbackType { get; set; }
        public string FeedbackText { get; set; }

        [ForeignKey("JobPositionFK")]
        public Guid JobPositionId { get; set; }
        public JobPosition JobPosition { get; set; }

        [ForeignKey("ApplicantFK")]
        public Guid ApplicantId { get; set; }
        public Person Applicant { get; set; }

        public ICollection<Interview> Interviews { get; set; }

    }
}
