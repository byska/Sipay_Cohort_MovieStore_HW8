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
    public class ActorConfiguration :BaseUserConfiguration<Actor>
    {
        public override void Configure(EntityTypeBuilder<Actor> builder)
        {
            base.Configure(builder);
            builder.HasMany(x => x.Movies).WithOne(x => x.Actor).HasForeignKey(x => x.ActorId);
        }
    }
}
