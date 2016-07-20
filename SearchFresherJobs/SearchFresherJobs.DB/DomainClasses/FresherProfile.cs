using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFresherJobs.DB.DomainClasses
{
    public class FresherProfile
    {
        /// <summary>
        /// Address of the fresher
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// City of the Candidate
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State of the candidate
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Country of the candidate
        /// </summary>
        public string Country { get; set; }
    }
}
