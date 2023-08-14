using Sipay_Cohort_MovieStore.Core.Entities.BaseEntities;
using Sipay_Cohort_MovieStore.Entities.Enums;

namespace Sipay_Cohort_MovieStore.Entities.DbSets
{
    public class Customer:BaseUser
    {
        public Customer()
        {
            Movies = new HashSet<Movie>();
            FavoriteGenres = new List<Genre>();
            Purchaseds = new HashSet<Purchased>();
        }
        public ICollection<Movie> Movies { get; set; }
        public List<Genre> FavoriteGenres { get; set; }
        public ICollection<Purchased> Purchaseds { get; set; }
    }
}
