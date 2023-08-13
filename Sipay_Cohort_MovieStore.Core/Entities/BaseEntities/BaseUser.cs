using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.Core.Entities.BaseEntities
{
    public class BaseUser:BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
