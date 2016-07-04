using SearchFresherJobs.DB;
using SearchFresherJobs.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Xml.Serialization;

namespace SearchFresherJobsAPI.Controllers
{
    public class AccountAPIController : ApiController
    {
        IAccountRepository _AccountRepository;
        public AccountAPIController(IAccountRepository accountRepository)
        {
            _AccountRepository = accountRepository;
        }

        /// <summary>
        /// api to register a user 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Register(string email, string password, string firstName, string lastName, short userType)
        {
            //Checking whether any of the field is empty
            if (!ValidateRegisterRequest(email, password, firstName, lastName, userType))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid request");
            }
            tblUser user = _AccountRepository.GetUserDetails(email, userType);
            if (user != null)   // check if user already exists
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, new HttpError("User Already Registered"));
            }
            try
            {
                string encryptedPassword = GetEncryptedPassword(password);
                long userId = _AccountRepository.CreateUser(firstName, lastName, encryptedPassword, email, userType);

                return this.Request.CreateResponse(HttpStatusCode.OK, new { UserProfileId = userId });
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, new HttpError(ex.Message));
            }
        }

        /// <summary>
        /// api to login a user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage Login(string email, string password, short userType)
        {
            try
            {
                tblUser userDetails = _AccountRepository.GetUserDetails(email, userType);
                if (userDetails != null)
                {
                    string decryptedPassword = DecryptPassword(userDetails.Password);
                    if (String.Equals(password, decryptedPassword))
                    {
                        return this.Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
                return Request.CreateResponse(HttpStatusCode.Unauthorized, new { Message = "User login failed" });
            }
            catch (Exception ex)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Validates if register user request is valid
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        private bool ValidateRegisterRequest(string email, string password, string firstName, string lastName, short userType)
        {
            if (!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password) && !String.IsNullOrEmpty(firstName) && !String.IsNullOrEmpty(lastName) && userType > 0)
            {
                return true;
            }
            return false;
        }

        #region "Private Methods"
        /// <summary>
        /// method to encrypt the password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private string GetEncryptedPassword(string password)
        {
            String pubKey = ConfigurationManager.AppSettings["PublicKeyString"];
            byte[] convertTest = Convert.FromBase64String(pubKey);
            string pubKeyString = Encoding.UTF8.GetString(convertTest);
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider(1024);
            csp.FromXmlString(pubKeyString);
            Byte[] bytesPlainTextData = Encoding.UTF8.GetBytes(password);
            String cypherText = Convert.ToBase64String(csp.Encrypt(bytesPlainTextData, false));
            return cypherText;
        }

        private string DecryptPassword(string cypherPassword)
        {
            String pvtKey = ConfigurationManager.AppSettings["PrivateKeyString"];
            Byte[] convertTest = Convert.FromBase64String(pvtKey);
            string pvtKeyString = Encoding.UTF8.GetString(convertTest);
            Byte[] bytesCypherText = Convert.FromBase64String(cypherPassword);
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            csp.FromXmlString(pvtKeyString);
            string plainTextData = Encoding.UTF8.GetString(csp.Decrypt(bytesCypherText, false));
            return plainTextData;
        }

        #endregion
    }
}
