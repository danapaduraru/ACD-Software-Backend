namespace Models.ModelHelper
{
    public static class EnumHelper
    {
        public enum QuestionType
        {
            OneChoice = 1,
            Text = 2
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
            Closed = 3,
            Cancelled = 4
        }

        public enum PersonType
        {
            Employee = 1,
            Applicant = 2
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

        public enum CheckAnswer
        {
            InReview = -1,
            Wrong = 0,
            Correct = 1
        }
    }
}
