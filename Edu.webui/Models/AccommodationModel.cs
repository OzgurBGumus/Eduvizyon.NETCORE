using System.ComponentModel.DataAnnotations;

namespace Edu.webui.Models
{
    public class AccommodationModel
    {
        public int AccommodationId { get; set; }
        public int BranchId { get; set; }
        [Required]
        public string RoomType { get; set; }
        [Required]
        public string MealType { get; set; }
        [Required]
        [Display(Name="Facility")]
        public string FacilityType { get; set; }
        [Required]
        [Range(1,200)]
        public int MinimumBooking { get; set; }
        [Required]
        [Range(1,200)]
        public int PricePerWeek { get; set; }
        [Required]
        public string DistanceFromSchool { get; set; }
        public bool Active { get; set; }
    }
}