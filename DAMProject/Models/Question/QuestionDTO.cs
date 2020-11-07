using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Question
{
    public class QuestionDTO : AddQuestionDTO
    {
        public Guid QuestionId { get; set; }
    }
}
