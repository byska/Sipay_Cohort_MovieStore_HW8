using Sipay_Cohort_MovieStore.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.Entities.DbSets
{
    public class Actor:BaseUser
    {
        public Actor()
        {
            Movies=new HashSet<MovieActor>();
        }
        public ICollection<MovieActor> Movies { get; set; }
    }
}
