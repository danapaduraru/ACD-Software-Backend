using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Application
{
    public class AddApplicationDTO
    {
        public Guid JobPositionId { get; set; }
        public Guid ApplicantId { get; set; }
    }
}
