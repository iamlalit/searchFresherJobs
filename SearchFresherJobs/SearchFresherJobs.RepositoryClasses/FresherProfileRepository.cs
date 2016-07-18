using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchFresherJobs.DB.DomainClasses;
using SearchFresherJobs.RepositoryInterfaces;
using SearchFresherJobs.DB;
using System.Data.Entity;

namespace SearchFresherJobs.RepositoryClasses
{
    public class FresherProfileRepository : IFresherProfileRepository
    {
        DbContext _DbContext;

        public FresherProfileRepository(SearchFresherJobsEntities searchFresherJobsEntities)
        {
            _DbContext = searchFresherJobsEntities;
        }

        /// <summary>
        /// Gets the fresher profile details based on the email id
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public FresherProfile Get(string email)
        {
            //Animesh: Use Automapper in the project
            return (from u in _DbContext.Set<tblUser>()
                    join f in _DbContext.Set<tblFresher>()
                    on u.UserId equals f.UserId
                    where u.Email == email
                    select new FresherProfile
                    {
                        Address = f.Address,
                        City = f.City,
                        Country = f.Counrty,
                        State = f.Counrty
                    }).FirstOrDefault();
        }
    }
}
