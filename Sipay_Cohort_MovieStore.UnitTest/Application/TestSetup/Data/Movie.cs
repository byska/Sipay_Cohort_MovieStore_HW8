using Sipay_Cohort_MovieStore.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.UnitTest.Application.TestSetup.Data
{
    public static class Movie
    {
        public static void AddMovie(this MovieStoreDbContext context)
        {
            context.Movies.AddRange(
               new Entities.DbSets.Movie { Name = "Modern Times", CreatedBy = "admin", CustomerId = 1, DirectorId = 2, Genre = Entities.Enums.Genre.action, Price = 250, Year = 1936 },
               new Entities.DbSets.Movie { Name = "A Clockwork Orange", CreatedBy = "admin", CustomerId = 2, DirectorId = 1, Genre = Entities.Enums.Genre.action, Price = 320, Year = 1971 },
               new Entities.DbSets.Movie { Name = "The Great Dictator", CreatedBy = "admin", CustomerId = 3, DirectorId = 2, Genre = Entities.Enums.Genre.romantic, Price = 120, Year = 1940 });
        }
    }
}
