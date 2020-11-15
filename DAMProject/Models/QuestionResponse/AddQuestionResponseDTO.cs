using Models.ModelHelper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.QuestionResponse
{
    public class AddQuestionResponseDTO
    {
        public Guid TestId { get; set; }
        public Guid InterviewId { get; set; }
        public Guid QuestionId { get; set; }
        public string Answer { get; set; }
        public EnumHelper.CheckAnswer CheckAnswer { get; set; }
    }
}
