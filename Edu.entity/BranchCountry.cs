namespace Edu.entity
{
    public class BranchCountry
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}