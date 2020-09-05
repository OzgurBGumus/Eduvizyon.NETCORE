using System.Collections.Generic;

namespace Edu.entity
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string Iban { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public int? PriceVisa { get; set; }
        public int? PriceHealthInsurance { get; set; }
        public int? PriceAirportPickup { get; set; }
        public int? Discount { get; set; }
        public bool IsDeleted { get; set; }
        public List<BranchCountry> BranchCountry { get; set; }
        public List<BranchState> BranchState { get; set; }
        public List<BranchCity> BranchCity { get; set; }
        public List<BranchBImage> BranchBImage { get; set; }
        public List<BranchCourse> BranchCourse { get; set; }
        public List<BranchAccommodation> BranchAccommodation { get; set; }
        public List<SchoolBranch> SchoolBranch { get; set; }
        public bool Active { get; set; }

    }
}