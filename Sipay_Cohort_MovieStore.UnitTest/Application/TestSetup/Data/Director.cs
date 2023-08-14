using Sipay_Cohort_MovieStore.DataAccess.Context;
using DirectorModel = Sipay_Cohort_MovieStore.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.UnitTest.Application.TestSetup.Data
{
    public static class Director
    {
        public static void AddDirector(this MovieStoreDbContext context)
        {
            context.Directors.AddRange(
                new DirectorModel.Director { Firstname = "Stanley", Lastname = "Kubrick", CreatedBy = "admin" },
                new DirectorModel.Director { Firstname = "Charlie", Lastname = "Chaplin", CreatedBy = "admin", },
                new DirectorModel.Director { Firstname = "Hayao", Lastname = "Miyazaki", CreatedBy = "admin" });
        }
    }
}
