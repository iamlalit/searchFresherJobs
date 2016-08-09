﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchFresherJobs.DB.DomainClasses;

namespace SearchFresherJobs.RepositoryInterfaces
{
    public interface IFresherProfileRepository
    {
        /// <summary>
        /// Gets the fresher profile data on the basis of email id
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        FresherProfile Get(int id);

        /// <summary>
        /// Posts the fresher profile data
        /// </summary>
        /// <param name="fresherProfile"></param>
        /// <returns></returns>
        bool Post(FresherProfile fresherProfile);

        /// <summary>
        /// Update the fresher profile data
        /// </summary>
        /// <param name="fresherProfile"></param>
        /// <returns></returns>
        bool Put(FresherProfile fresherProfile);
    }
}
