using Entities.EntityHelper.RelationshipEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class QuestionResponse
    {
        public Guid QuestionResponseId { get; set; }

        [ForeignKey("QRTestFK")]
        public Guid TestId { get; set; }
        public Test Test { get; set; }

        [ForeignKey("QRInterviewFK")]
        public Guid InterviewId { get; set; }
        public Interview Interview { get; set; }

        [ForeignKey("QRQuestionFK")]
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }

        public string Answer { get; set; }
        public Helper.CheckAnswer CheckAnswer { get; set; }



    }
}
