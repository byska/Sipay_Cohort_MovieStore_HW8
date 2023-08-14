using Sipay_Cohort_MovieStore.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.UnitTest.Application.TestSetup.Data
{
    public static class Customer
    {
        public static void AddCustomer(this MovieStoreDbContext context)
        {
            context.Customers.AddRange(
                new Entities.DbSets.Customer { Firstname = "John", Lastname = "Doe", CreatedBy = "admin", Email = "john.doe@gmail.com", FavoriteGenres = new List<Entities.Enums.Genre> { Entities.Enums.Genre.romantic, Entities.Enums.Genre.action }, Password = "JohnDoe123" },
                new Entities.DbSets.Customer { Firstname = "Jeyn", Lastname = "Doe", CreatedBy = "admin", Email = "jeyn.doe@gmail.com", FavoriteGenres = new List<Entities.Enums.Genre> { Entities.Enums.Genre.sciencefiction, Entities.Enums.Genre.action }, Password = "JeynDoe123" },
                new Entities.DbSets.Customer { Firstname = "Tommy", Lastname = "Doe", CreatedBy = "admin", Email = "tommy.doe@gmail.com", FavoriteGenres = new List<Entities.Enums.Genre> { Entities.Enums.Genre.romantic }, Password = "TommyDoe123" });
        }
    }
}
