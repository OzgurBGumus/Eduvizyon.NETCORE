namespace Edu.entity
{
    public class BranchCity
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}