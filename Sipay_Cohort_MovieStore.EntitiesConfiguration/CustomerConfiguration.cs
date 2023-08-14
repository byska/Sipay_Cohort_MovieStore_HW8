using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sipay_Cohort_MovieStore.Core.Entities.EntityTypeConfigurations;
using Sipay_Cohort_MovieStore.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.EntitiesConfiguration
{
    public class CustomerConfiguration:BaseUserConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);
            builder.HasMany(x => x.Movies).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);
            builder.HasMany(x => x.Purchaseds).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId);

        }
    }
}
