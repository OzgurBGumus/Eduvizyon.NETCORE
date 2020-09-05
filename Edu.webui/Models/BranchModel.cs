using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Edu.webui.Models
{
    public class BranchModel
    {
        public int BranchId { get; set; }


        [Required(ErrorMessage="Iban is required.")]
        [Display(Name="Iban", Prompt="Enter Branch Iban")]
        public string Iban { get; set; }

        [Required(ErrorMessage="Email is required.")]
        [Display(Name="Email", Prompt="Enter Branch Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage="Phone is required.")]
        [Display(Name="Phone", Prompt="Enter Branch Phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage="Adress is required.")]
        [Display(Name="Adress", Prompt="Enter Branch Adress")]
        public string Adress { get; set; }

        [Range(1,100000)]
        public int? PriceVisa { get; set; }

        [Range(1,100000)]
        public int? PriceHealthInsurance { get; set; }

        [Range(1,100000)]
        public int? PriceAirportPickup { get; set; }

        [Range(1,100)]
        public int? Discount { get; set; }

        [Required(ErrorMessage="Country is required.")]
        [Display(Name="Country", Prompt="Enter Branch Country")]
        public int CountryId { get; set; }

        [Required(ErrorMessage="State is required.")]
        [Display(Name="State", Prompt="Enter Branch State")]
        public int StateId { get; set; }

        [Required(ErrorMessage="City is required.")]
        [Display(Name="City", Prompt="Enter Branch City")]
        public int CityId { get; set; }

        [Required(ErrorMessage="School is required. (If You Get this, there is something wrong.)")]
        [Display(Name="School", Prompt="Enter Branch School (If You Get this, there is something wrong.)")]
        public int SchoolId { get; set; }
        public List<int> BImageIds { get; set; }
        public List<int> CourseIds { get; set; }
        public List<int> AccommodationIds { get; set; }

        [Required(ErrorMessage="Active is required. (If You Get this, there is something wrong.)")]
        [Display(Name="Active", Prompt="Enter Branch Active (If You Get this, there is something wrong.)")]
        public bool Active { get; set; }
    }
}