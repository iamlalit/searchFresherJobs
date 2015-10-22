using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFresherJobs.DB.DomainClasses
{
    public class SearchJobDetail
    {
        public string title { get; set; }
        public string organization { get; set; }
        public string city { get; set; }
        public string deeplink { get; set; }
        public string summary { get; set; }
        public DateTime? createddate { get; set; }
        public DateTime? updateddate { get; set; }
    }
}
