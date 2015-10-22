using SearchFresherJobs.DB.DomainClasses;
using SearchFresherJobs.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SearchFresherJobsAPI.Controllers
{
    public class SearchAPIController : ApiController
    {
        ISearchJobsRepository _SearchJobsRepository;

        public SearchAPIController(ISearchJobsRepository searchJobsRepository)
        {
            _SearchJobsRepository = searchJobsRepository;
        }

        [HttpGet]
        public HttpResponseMessage GetJobDataForSearch(string keyword, string location)
        {
            try
            {
                List<SearchJobDetail> searchJobDetailList = _SearchJobsRepository.GetDataForSearch(keyword, location);
                return this.Request.CreateResponse(HttpStatusCode.OK, searchJobDetailList);
            }
            catch (Exception ex)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}