using Sipay_Cohort_MovieStore.Entities.Enums;

namespace Sipay_Cohort_MovieStore.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
        public decimal Price { get; set; }

    }
}
