using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Test
    {
        public Guid TestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HoursLimitTime { get; set; }
        public int MinutesLimitTime { get; set; }


        public ICollection<TestToQuestions> TestToQuestions { get; set; }
    }
}
