using System;
using System.Collections.Generic;
using System.Text;

namespace Models.ModelHelper
{
    public static class EnumHelper
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

        public enum PositionStatus
        {
            Open = 1,
            Soon = 2,
            Close = 3,
            Cancelled = 4
        }
    }
}
