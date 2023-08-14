using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sipay_Cohort_MovieStore.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.Core.Entities.EntityTypeConfigurations
{
    public class BaseUserConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseUser
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.CreatedBy).HasMaxLength(128).IsRequired();
            builder.Property(x => x.ModifiedDate).IsRequired(false);
            builder.Property(x => x.ModifiedBy).HasMaxLength(128).IsRequired(false);
            builder.Property(x => x.DeletedDate).IsRequired(false);
            builder.Property(x => x.DeletedBy).HasMaxLength(128).IsRequired(false);
            builder.Property(x => x.Firstname).HasMaxLength(125).IsRequired();
            builder.Property(x => x.Lastname).IsRequired().HasMaxLength(125);
        }
    }
}
