using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SearchFresherJobs.DB.DomainClasses;
using SearchFresherJobs.RepositoryInterfaces;

namespace SearchFresherJobsAPI.Controllers
{
    public class FresherProfileAPIController : ApiController
    {
        IFresherProfileRepository _FresherProfileRepository;
        public FresherProfileAPIController(IFresherProfileRepository fresherProfileRepository)
        {
            _FresherProfileRepository = fresherProfileRepository;
        }

        /// <summary>
        /// Get fresher basic profile data 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Get(string email)
        {
            FresherProfile fresherProfileData = null;
            if (string.IsNullOrWhiteSpace(email))
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, new HttpError("Email id is blank"));
            }
            try
            {
                fresherProfileData = _FresherProfileRepository.Get(email);
                return this.Request.CreateResponse(HttpStatusCode.OK, fresherProfileData);
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new HttpError(ex.Message));
            }
        }


        /// <summary>
        /// Post fresher basic profile data 
        /// </summary>
        /// <param name="fresherProfile"></param>
        [HttpPost]
        public HttpResponseMessage Post(FresherProfile fresherProfile)
        {
            try
            {
                if (fresherProfile != null)
                {
                    var result = _FresherProfileRepository.Post(fresherProfile);
                    if (result)
                    {
                        return this.Request.CreateResponse(HttpStatusCode.OK, true);
                    }
                }
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, false);
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new HttpError(ex.Message));
            }
        }

    }
}
