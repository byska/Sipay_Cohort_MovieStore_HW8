using Sipay_Cohort_MovieStore.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.Entities.DbSets
{
    public class Purchased:BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public decimal Price { get; set; }
    }
}
