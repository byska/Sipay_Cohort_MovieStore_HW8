using Microsoft.EntityFrameworkCore;
using Sipay_Cohort_MovieStore.Entities.DbSets;
using Sipay_Cohort_MovieStore.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.DataAccess.Context
{
    public class MovieStoreDbContext :DbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options)
        {

        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Purchased> Purchaseds { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new DirectorConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new PurchasedConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
