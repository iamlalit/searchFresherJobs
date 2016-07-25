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

        /// <summary>
        /// Fresher id of the fresher
        /// </summary>
        public long FresherId { get; set; }

        /// <summary>
        /// User id of the fresher
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Delete status of profile id
        /// </summary>
        public bool DeleteStatus { get; set; }

        /// <summary>
        /// Date of birth of fresher
        /// </summary>
        public DateTime DOB { get; set; }

        /// <summary>
        /// Gender of fresher
        /// </summary>
        public short Gender { get; set; }

        /// <summary>
        /// Marital Status of fresher
        /// </summary>
        public short MaritalStatus { get; set; }

        /// <summary>
        /// Profile summary of fresher
        /// </summary>
        public string ProfileSummary { get; set; }

        /// <summary>
        /// Preferred job locations of fresher
        /// </summary>
        public List<int> PreferredLocation { get; set; }

        /// <summary>
        /// Functional area of fresher
        /// </summary>
        public List<int> FunctionalArea { get; set; }

        /// <summary>
        /// Industry in which seeking job
        /// </summary>
        public List<int> Industry { get; set; }
    }
}
