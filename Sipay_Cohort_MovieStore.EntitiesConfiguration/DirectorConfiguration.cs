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
    public class DirectorConfiguration:BaseUserConfiguration<Director>
    {
        public override void Configure(EntityTypeBuilder<Director> builder)
        {
            base.Configure(builder);
            builder.HasMany(x=>x.Movies).WithOne(x => x.Director).HasForeignKey(x=>x.DirectorId);
        }
    }
}
