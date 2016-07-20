using SearchFresherJobs.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web;
using System.Web.Http.Cors;
using System.Net.Http;
using SearchFresherJobs.DB;
using SearchFresherJobs.RepositoryClasses.Common;
using SearchFresherJobs.DB.DomainClasses;
using Newtonsoft.Json;

namespace SearchFresherJobsAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class JobsAPIController : ApiController
    {
        ISearchJobsRepository _SearchJobsRepository;
        IAccountRepository _AccountRepository;

        public JobsAPIController (ISearchJobsRepository searchJobsRepository, IAccountRepository accountRepository)
        {
            _SearchJobsRepository = searchJobsRepository;
            _AccountRepository = accountRepository;
        }

        /// <summary>
        /// Api to create a new job
        /// </summary>
        /// <param name="jobDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage CreateNewJob(dynamic data)
        {
            try
            {
                tblFresherJob jobDetails = new tblFresherJob();
                FresherJobModel fresherJobDetails = JsonConvert.DeserializeObject<FresherJobModel>(JsonConvert.SerializeObject(data.NewJobDetails));
                long publicUserProfileId = JsonConvert.DeserializeObject<long>(JsonConvert.SerializeObject(data.PublicUserProfileId));
                string errorMessage = ValidateJobRequest(jobDetails);
                if (string.IsNullOrEmpty(errorMessage))
                {
                    return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, errorMessage);
                }
                tblUser user = _AccountRepository.GetUserDetailsByPublicUserId(publicUserProfileId);
                if (user.UserTypeId != (short)UserType.Organization)
                {
                    return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid request");
                }
                jobDetails.Title = fresherJobDetails.title;
                jobDetails.Description = fresherJobDetails.description;
                jobDetails.Salary = fresherJobDetails.salary;
                jobDetails.Location = fresherJobDetails.location;
                jobDetails.UserId = user.UserId;
                _SearchJobsRepository.CreateFresherJob(jobDetails);
                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Validates if job details are valid
        /// </summary>
        /// <param name="jobDetails"></param>
        /// <returns></returns>
        private string ValidateJobRequest(tblFresherJob jobDetails)
        {
            string errorMessage = string.Empty;
            if (string.IsNullOrEmpty(jobDetails.Title))
            {
                errorMessage = "Job title can't be empty.";
            }
            else if (string.IsNullOrEmpty(jobDetails.Description))
            {
                errorMessage = "Job description can't be empty.";
            }
            else if (jobDetails.UserId <= 0)
            {
                errorMessage = "Invalid request";
            }
            return errorMessage;
        }
    }
}