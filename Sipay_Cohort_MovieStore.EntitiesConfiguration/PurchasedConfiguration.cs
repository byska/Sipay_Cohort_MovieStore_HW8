using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sipay_Cohort_MovieStore.Core.Entities.BaseEntities;
using Sipay_Cohort_MovieStore.Core.Entities.EntityTypeConfigurations;
using Sipay_Cohort_MovieStore.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.EntitiesConfiguration
{
    public class PurchasedConfiguration: BaseEntityConfiguration<Purchased>
    {
        public override void Configure(EntityTypeBuilder<Purchased> builder)
        {
            base.Configure(builder);
            builder.Property(x=>x.Price).IsRequired();
        }
    }
}
