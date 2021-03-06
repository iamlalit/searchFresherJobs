﻿using SearchFresherJobs.DB;
using SearchFresherJobs.DB.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFresherJobs.RepositoryInterfaces
{
    public interface ISearchJobsRepository
    {
        List<SearchJobDetail> GetDataForSearch(string keyword, string location);

        /// <summary>
        /// Creates new fresher job
        /// </summary>
        /// <param name="jobDetails"></param>
        void CreateFresherJob(tblFresherJob jobDetails);
    }
}
