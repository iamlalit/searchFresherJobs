//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SearchFresherJobs.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblFresherPreferredLocation
    {
        public long FresherPreferredLocationId { get; set; }
        public Nullable<long> FresherProfileId { get; set; }
        public Nullable<long> FresherPreferredLocation { get; set; }
    
        public virtual tblFresher tblFresher { get; set; }
    }
}
