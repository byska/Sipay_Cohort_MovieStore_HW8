using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sipay_Cohort_MovieStore.Business.Mapping;
using Sipay_Cohort_MovieStore.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.UnitTest.Application.TestSetup.Data
{
    public class CommonTestFixture
    {
        public MovieStoreDbContext context { get; set; }
        public IMapper Mapper { get; set; }
        public CommonTestFixture()
        {
            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            }).CreateMapper();

            var options = new DbContextOptionsBuilder<MovieStoreDbContext>().UseInMemoryDatabase("name : MovieStoreDb").Options;
            context = new MovieStoreDbContext(options);

            context.Database.EnsureCreated();

            context.AddActors();
            context.AddCustomer();
            context.AddDirector();
            context.AddMovie();
            context.AddMovieActor();
            context.AddPurchased();
        }

    }
}
