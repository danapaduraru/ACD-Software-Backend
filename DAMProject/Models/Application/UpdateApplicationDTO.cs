using Models.ModelHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Application
{
    public class UpdateApplicationDTO
    {
        public EnumHelper.ApplicationStatus Status { get; set; }
        public EnumHelper.FeedbackType FeedbackType { get; set; }
        public string FeedbackText { get; set; }
    }
}
