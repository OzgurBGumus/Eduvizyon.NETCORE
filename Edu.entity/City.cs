using System.Collections.Generic;

namespace Edu.entity
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool IsDeleted { get; set; }
        public List<BranchCity> BranchCities { get; set; }
        public List<StateCity> StateCities { get; set; }
        public List<CountryCity> CountryCities { get; set; }
    }
}