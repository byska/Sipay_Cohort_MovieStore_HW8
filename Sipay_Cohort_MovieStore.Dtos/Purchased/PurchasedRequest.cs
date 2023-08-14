using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.Dtos.Purchased
{
    public class PurchasedRequest
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
