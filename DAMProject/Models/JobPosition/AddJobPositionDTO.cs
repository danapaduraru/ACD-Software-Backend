using System;
using Models.ModelHelper;

namespace Models.JobPosition
{
    public class AddJobPositionDTO
    {
        public EnumHelper.PositionStatus Status { get; set; }
        public string Position { get; set; }
        public string Level { get; set; }
        public string Description { get; set; }
        public DateTime ApplicationDeadline { get; set; }
        public DateTime StartDate { get; set; }
    }
}
