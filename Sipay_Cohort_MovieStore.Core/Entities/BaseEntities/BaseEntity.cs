using Sipay_Cohort_MovieStore.Core.Entities.Interfaces;

namespace Sipay_Cohort_MovieStore.Core.Entities.BaseEntities
{
    public class BaseEntity :IEntity
    {
        public int Id { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
