using System.Collections.Generic;

namespace Edu.entity
{
    public class Accommodation
    {
        public int AccommodationId { get; set; }
        public string RoomType { get; set; }
        public string MealType { get; set; }
        public string FacilityType { get; set; }
        public int MinimumBooking { get; set; }
        public int PricePerWeek { get; set; }
        public string DistanceFromSchool { get; set; }
        public bool Active { get; set; }
        public bool IsDeleted { get; set; }
        public List<BranchAccommodation> BranchAccommodation { get; set; }
    }
}