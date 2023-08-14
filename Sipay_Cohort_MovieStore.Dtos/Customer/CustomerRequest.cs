using Sipay_Cohort_MovieStore.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.Dtos.Customer
{
    public class CustomerRequest
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<Genre> FavoriteGenres { get; set; }
    }
}
