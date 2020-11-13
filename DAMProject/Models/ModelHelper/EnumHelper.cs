﻿namespace Models.ModelHelper
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

        public enum PersonType
        {
            Applicant = 1,
            Employee = 2
        }

        public enum ApplicationStatus
        {
            Pending = 1,
            AcceptedForInterview = 2,
            InReview = 3,
            Finalized = 4
        }

        public enum FeedbackType
        {
            None = 0,
            Pending = 1,
            Accepted = 2,
            Rejected = 3,
        }
    }
}
