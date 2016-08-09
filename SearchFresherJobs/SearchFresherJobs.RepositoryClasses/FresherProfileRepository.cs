using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchFresherJobs.DB.DomainClasses;
using SearchFresherJobs.RepositoryInterfaces;
using SearchFresherJobs.DB;
using System.Data.Entity;
using System.Transactions;

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
        public FresherProfile Get(int id)
        {
            long longId = (long)id;
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
                                  where u.UserId == longId
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
                                      MaritalStatus = f.MaritalStatus ?? 0,
                                      ProfileSummary = f.ProfileSummary,
                                      FunctionalArea = fa.FresherFunctionalArea ?? 0,
                                      Industry = fi.FresherPreferredIndustry,
                                      PreferredLocation = fp.FresherPreferredLocation ?? 0
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
                FunctionalAreaList = fresherProfile.Select(f => f.FunctionalArea).Distinct().ToList(),
                IndustryList = fresherProfile.Select(f => f.Industry).Distinct().ToList(),
                PreferredLocationList = fresherProfile.Select(f => f.PreferredLocation).Distinct().ToList()
            };
        }

        /// <summary>
        /// Posts the fresher profile data
        /// </summary>
        /// <param name="fresherProfile"></param>
        /// <returns></returns>
        public bool Post(FresherProfile fresherProfile)
        {
            DateTime currDate = DateTime.UtcNow;
            tblFresher tblFresherProfile = new tblFresher();
            tblFresherProfile.Address = fresherProfile.Address;
            tblFresherProfile.City = fresherProfile.City;
            tblFresherProfile.Counrty = fresherProfile.Country;
            tblFresherProfile.CreatedDate = currDate;
            tblFresherProfile.UpdatedDate = currDate;
            tblFresherProfile.DeleteStatus = false;
            tblFresherProfile.DOB = currDate;//DevNote:Insert the correct dob from the date ui control
            tblFresherProfile.FresherId = fresherProfile.FresherId;//DevNote:Take this out from session
            tblFresherProfile.Gender = fresherProfile.Gender;
            tblFresherProfile.MaritalStatus = fresherProfile.MaritalStatus;
            tblFresherProfile.ProfileSummary = fresherProfile.ProfileSummary;
            tblFresherProfile.State = fresherProfile.State;
            tblFresherProfile.UserId = fresherProfile.UserId;
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

        /// <summary>
        /// Updates the fresher profile data
        /// </summary>
        /// <param name="fresherProfile"></param>
        /// <returns></returns>
        public bool Put(FresherProfile fresherProfile)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    DateTime currDate = DateTime.UtcNow;

                    tblFresher tblFresherProfile = _DbContext.Set<tblFresher>().FirstOrDefault(t => t.UserId == fresherProfile.UserId);
                    tblFresherProfile.Address = fresherProfile.Address;
                    tblFresherProfile.City = fresherProfile.City;
                    tblFresherProfile.Counrty = fresherProfile.Country;
                    tblFresherProfile.CreatedDate = currDate;
                    tblFresherProfile.UpdatedDate = currDate;
                    tblFresherProfile.DeleteStatus = false;
                    tblFresherProfile.DOB = currDate;//DevNote:Insert the correct dob from the date ui control
                    tblFresherProfile.FresherId = fresherProfile.FresherId;//DevNote:Take this out from session
                    tblFresherProfile.Gender = fresherProfile.Gender;
                    tblFresherProfile.MaritalStatus = fresherProfile.MaritalStatus;
                    tblFresherProfile.ProfileSummary = fresherProfile.ProfileSummary;
                    tblFresherProfile.State = fresherProfile.State;
                    tblFresherProfile.UserId = fresherProfile.UserId;
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

                    var functionalAreaDelete = _DbContext.Set<tblFresherFunctionalArea>().Where(f => f.FresherProfileId == fresherProfile.FresherId);
                    _DbContext.Entry(functionalAreaDelete).State = EntityState.Deleted;
                    _DbContext.SaveChanges();

                    var prefLocDelete = _DbContext.Set<tblFresherPreferredLocation>().Where(f => f.FresherProfileId == fresherProfile.FresherId);
                    _DbContext.Entry(prefLocDelete).State = EntityState.Deleted;
                    _DbContext.SaveChanges();

                    var prefIndustryDelete = _DbContext.Set<tblFresherPreferredIndustry>().Where(f => f.FresherProfileId == fresherProfile.FresherId);
                    _DbContext.Entry(functionalAreaDelete).State = EntityState.Deleted;
                    _DbContext.SaveChanges();
                    scope.Complete();
                }
                catch(Exception ex)
                {

                }
                
            }



            return true;
        }
    }
}
