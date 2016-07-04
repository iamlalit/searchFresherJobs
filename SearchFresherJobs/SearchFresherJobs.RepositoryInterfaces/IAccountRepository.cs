using SearchFresherJobs.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFresherJobs.RepositoryInterfaces
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Creates new user
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="encryptedPassword"></param>
        /// <param name="email"></param>
        /// <param name="userType"></param>
        long CreateUser(string firstName, string lastName, string encryptedPassword, string email, short userType);

        /// <summary>
        /// Gets user details
        /// </summary>
        /// <param name="email"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        tblUser GetUserDetails(string email, short userType);
    }
}
