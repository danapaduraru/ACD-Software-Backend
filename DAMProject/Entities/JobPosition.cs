using System;

namespace Entities
{
    public class JobPosition
    {
        public Guid JobPositionId { get; set; }
        public Helper.PositionStatus Status { get; set; }
        public string Position { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public DateTime ApplicationDeadline { get; set; }
        public DateTime StartDate { get; set; }
    }
}
