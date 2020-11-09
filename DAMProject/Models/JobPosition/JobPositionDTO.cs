using System;
using System.Collections.Generic;
using System.Text;

namespace Models.JobPosition
{
    public class JobPositionDTO : AddJobPositionDTO
    {
        public Guid JobPositionId { get; set; }
    }
}
