using SearchFresherJobs.DB;
using SearchFresherJobs.DB.DomainClasses;
using SearchFresherJobs.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFresherJobs.RepositoryClasses
{
    public class SearchJobsRepository : ISearchJobsRepository
    {
        DbContext _DBContext;
        public SearchJobsRepository(SearchJobsEntities searchJobsEntities)
        {
            _DBContext = searchJobsEntities;
        }

        public List<SearchJobDetail> GetDataForSearch(string keyword, string location)
        {
            location = location == null ? String.Empty : location;
            keyword = keyword == null ? String.Empty : keyword;

            return (from jobTable in _DBContext.Set<tblJob>()
                    where (jobTable.city.Contains(keyword) || jobTable.jobdescription.Contains(keyword) || jobTable.jobsummary.Contains(keyword))
                            && (jobTable.city.Contains(location) || jobTable.jobdescription.Contains(location))
                            && jobTable.isactive == true
                    select new SearchJobDetail
                    {
                        title = jobTable.jobtitle,
                        organization = jobTable.organization,
                        city = jobTable.city,
                        deeplink = jobTable.deeplink,
                        summary = jobTable.jobsummary,
                        createddate = jobTable.createddate,
                        updateddate = jobTable.updateddate
                    }).ToList();
        } 
    }
}
