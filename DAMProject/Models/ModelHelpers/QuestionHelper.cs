using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ModelHelpers
{
    public static class QuestionHelper
    {
        public enum QuestionType
        {
            Text = 1,
            OneChoice = 2,
        }

        public enum CorrectAnswer
        {
            NoAns = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }
    }
}
