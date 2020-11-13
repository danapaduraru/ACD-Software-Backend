using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class TestsToQuestions
    {
        
        public Guid TestsToQuestionsId { get; set; }

        [ForeignKey("TestFK")]
        public Guid TestId { get; set; }
        public Test Test { get; set; }

        [ForeignKey("QuestionFK")]
        public Guid QuestionID { get; set; }
        public Question Question { get; set; }
    }
}
