using Sipay_Cohort_MovieStore.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.UnitTest.Application.TestSetup.Data
{
    public static class Purchased
    {
        public static void AddPurchased(this MovieStoreDbContext context)
        {
            context.Purchaseds.AddRange(
              new Entities.DbSets.Purchased {CreatedBy="admin",CustomerId=1,MovieId=1,Price=250 },
              new Entities.DbSets.Purchased {CreatedBy="admin",CustomerId=1,MovieId=3,Price=120 },
              new Entities.DbSets.Purchased {CreatedBy="admin",CustomerId=3,MovieId=2,Price=320 });
        }
    }
}
