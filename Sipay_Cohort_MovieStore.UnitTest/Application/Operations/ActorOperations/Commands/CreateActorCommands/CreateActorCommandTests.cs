using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sipay_Cohort_MovieStore.Business.Services.Actor;
using Sipay_Cohort_MovieStore.DataAccess.Context;
using Sipay_Cohort_MovieStore.UnitTest.Application.TestSetup.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.UnitTest.Application.Operations.ActorOperations.Commands.CreateActorCommands
{
    public class CreateActorCommandTests
    {
        private readonly MovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateActorCommandTests(CommonTestFixture testFixture)
        {
            _dbContext = testFixture.context;
            _mapper = testFixture.Mapper;
        }
       
    }
}
