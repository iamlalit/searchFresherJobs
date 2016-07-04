using SearchFresherJobs.DB;
using SearchFresherJobs.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFresherJobs.RepositoryClasses
{
    public class AccountRepository : IAccountRepository
    {
        DbContext _DbContext;

        public AccountRepository (SearchFresherJobsEntities searchFresherJobsEntities)
        {
            _DbContext = searchFresherJobsEntities;
        }

        /// <summary>
        /// Creates new user
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="encryptedPassword"></param>
        /// <param name="email"></param>
        /// <param name="userType"></param>
        public long CreateUser(string firstName, string lastName, string encryptedPassword, string email, short userType)
        {
            DateTime curTime = DateTime.Now;
            tblUser userProfile = new tblUser();
            userProfile.FirstName = firstName;
            userProfile.LastName = lastName;
            userProfile.Email = email;
            userProfile.Password = encryptedPassword;
            userProfile.UserTypeId = userType;
            userProfile.UpdatedDate = curTime;
            userProfile.CreatedDate = curTime;

            _DbContext.Entry(userProfile).State = EntityState.Added;
            _DbContext.SaveChanges();

            return userProfile.UserId;
        }

        /// <summary>
        /// Gets user details
        /// </summary>
        /// <param name="email"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        public tblUser GetUserDetails(string email, short userType)
        {
            tblUser userDetails = _DbContext.Set<tblUser>().FirstOrDefault(x => x.Email == email && x.UserTypeId == userType && x.DeleteStatus == false);
            return userDetails;
        }
    }
}
