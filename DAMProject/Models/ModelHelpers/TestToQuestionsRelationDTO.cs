using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ModelHelpers
{
    public class TestToQuestionsRelationDTO
    {
        public Guid TestId { get; set; }
        public Guid QuestionID { get; set; }
    }
}
