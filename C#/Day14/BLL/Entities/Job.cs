using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{
    public class Job
    {
        public Job() { }
        public required short Job_id { get; set; }
        public required string Job_desc { get; set; }
        public required Byte Min_lvl { get; set; }
        public required Byte Max_lvl { get; set; }
    }
}
