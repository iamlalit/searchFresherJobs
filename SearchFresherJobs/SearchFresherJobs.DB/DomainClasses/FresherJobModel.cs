using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFresherJobs.DB.DomainClasses
{
    public class FresherJobModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public string salary { get; set; }
        public string location { get; set; }
    }
}
