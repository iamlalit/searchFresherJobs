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
            var fresherProfile = (from u in _DbContext.Set<tblUser>()
                                  join f in _DbContext.Set<tblFresher>()
                                  on u.UserId equals f.UserId
                                  join fn in _DbContext.Set<tblFresherFunctionalArea>()
                                  on f.FresherId equals fn.FresherProfileId into funcArea
                                  from fa in funcArea.DefaultIfEmpty()
                                  join p in _DbContext.Set<tblFresherPreferredLocation>()
                                  on f.FresherId equals p.FresherProfileId into frProfile
                                  from fp in frProfile.DefaultIfEmpty()
                                  join i in _DbContext.Set<tblFresherPreferredIndustry>()
                                  on f.FresherId equals i.FresherProfileId into frInd
                                  from fi in frInd.DefaultIfEmpty()
                                  where u.Email == email
                                  select new FresherProfile
                                  {
                                      Address = f.Address,
                                      City = f.City,
                                      Country = f.Counrty,
                                      State = f.State,
                                      DeleteStatus = f.DeleteStatus,
                                      DOB = f.DOB,
                                      FresherId = f.FresherId,
                                      UserId = f.UserId,
                                      Gender = f.Gender,
                                      MaritalStatus = f.MaritalStatus == null ? (byte)0 : f.MaritalStatus.Value,
                                      ProfileSummary = f.ProfileSummary,
                                      FunctionalArea = fa.FresherFunctionalArea == null ? (long)0 : fa.FresherFunctionalArea.Value,
                                      Industry = fi.FresherPreferredIndustry,
                                      PreferredLocation = fp.FresherPreferredLocation == null ? (long)0 : fp.FresherPreferredLocation.Value
                                  }).ToList();

            return new FresherProfile
            {
                Address = fresherProfile[0].Address,
                City = fresherProfile[0].City,
                Country = fresherProfile[0].Country,
                DeleteStatus = fresherProfile[0].DeleteStatus,
                DOB = fresherProfile[0].DOB,
                FresherId = fresherProfile[0].FresherId,
                Gender = fresherProfile[0].Gender,
                State = fresherProfile[0].State,
                MaritalStatus = fresherProfile[0].MaritalStatus,
                UserId = fresherProfile[0].UserId,
                ProfileSummary = fresherProfile[0].ProfileSummary,
                FunctionalAreaList = fresherProfile.Select(f => f.FunctionalArea).ToList(),
                IndustryList = fresherProfile.Select(f => f.Industry).ToList(),
                PreferredLocationList = fresherProfile.Select(f => f.PreferredLocation).ToList()
            };
        }

        /// <summary>
        /// Posts the fresher profile data
        /// </summary>
        /// <param name="fresherProfile"></param>
        /// <returns></returns>
        public bool Post(FresherProfile fresherProfile)
        {
            DateTime currDate = new DateTime();
            tblFresher tblFresherProfile = new tblFresher();
            tblFresherProfile.Address = fresherProfile.Address;
            tblFresherProfile.City = fresherProfile.City;
            tblFresherProfile.Counrty = fresherProfile.Country;
            tblFresherProfile.CreatedDate = currDate;
            tblFresherProfile.UpdatedDate = currDate;
            tblFresherProfile.DeleteStatus = false;
            tblFresherProfile.DOB = fresherProfile.DOB;
            tblFresherProfile.FresherId = fresherProfile.FresherId;//Take this out from session
            tblFresherProfile.Gender = fresherProfile.Gender;
            tblFresherProfile.MaritalStatus = fresherProfile.MaritalStatus;
            tblFresherProfile.ProfileSummary = fresherProfile.ProfileSummary;
            tblFresherProfile.State = fresherProfile.State;
            foreach (long item in fresherProfile.FunctionalAreaList)
            {
                tblFresherProfile.tblFresherFunctionalAreas.Add(new tblFresherFunctionalArea { FresherFunctionalArea = item, FresherProfileId = fresherProfile.FresherId });
            }
            foreach (long item in fresherProfile.PreferredLocationList)
            {
                tblFresherProfile.tblFresherPreferredLocations.Add(new tblFresherPreferredLocation { FresherPreferredLocation = item, FresherProfileId = fresherProfile.FresherId });
            }

            foreach (long item in fresherProfile.IndustryList)
            {
                tblFresherProfile.tblFresherPreferredIndustries.Add(new tblFresherPreferredIndustry { FresherPreferredIndustry = item, FresherProfileId = fresherProfile.FresherId });
            }

            _DbContext.Entry(tblFresherProfile).State = EntityState.Added;
            _DbContext.SaveChanges();

            return true;
        }
    }
}
