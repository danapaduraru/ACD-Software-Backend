using Models.ModelHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Question
{
    public class AddQuestionDTO
    {
        public string Quest { get; set; }
        public QuestionHelper.QuestionType QuestionType { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Option5 { get; set; }
        public QuestionHelper.CorrectAnswer CorrectAnswer { get; set; }
        public string TextAnswer { get; set; }
        public bool Cancelled { get; set; }
    }
}
