using System.Collections.Generic;

namespace Edu.entity
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool IsDeleted { get; set; }
        public List<BranchCountry> BranchCountries { get; set; }
        public List<CountryState> CountryStates { get; set; }
        public List<CountryCity> CountryCities { get; set; }
    }
}