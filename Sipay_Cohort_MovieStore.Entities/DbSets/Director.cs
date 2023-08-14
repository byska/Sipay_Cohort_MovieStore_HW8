using Sipay_Cohort_MovieStore.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.Entities.DbSets
{
    public class Director:BaseUser
    {
        public Director()
        {
            Movies = new HashSet<Movie>();
        }
        public ICollection<Movie> Movies { get; set; }
    }
}
