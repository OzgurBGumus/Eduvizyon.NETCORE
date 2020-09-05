namespace Edu.entity
{
    public class CountryCity
    {
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}