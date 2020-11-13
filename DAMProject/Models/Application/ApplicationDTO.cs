using Models.ModelHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Application
{
    public class ApplicationDTO
    {
        public Guid ApplicationId { get; set; }
        public DateTime ApplicationDate { get; set; }
        public EnumHelper.ApplicationStatus Status { get; set; }
        public EnumHelper.FeedbackType FeedbackType { get; set; }
        public string FeedbackText { get; set; }
        public Guid JobPositionId { get; set; }
        public Guid ApplicantId { get; set; }
    }
}
