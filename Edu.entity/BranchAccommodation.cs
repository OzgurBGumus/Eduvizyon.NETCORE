namespace Edu.entity
{
    public class BranchAccommodation
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int AccommodationId { get; set; }
        public Accommodation Accommodation { get; set; }
    }
}