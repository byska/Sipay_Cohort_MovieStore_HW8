using Sipay_Cohort_MovieStore.Core.Entities.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.Entities.DbSets
{
    public class MovieActor:BaseEntity
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
