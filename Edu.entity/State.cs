using System.Collections.Generic;

namespace Edu.entity
{
    public class State
    {
        public int StateId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool IsDeleted { get; set; }
        public List<BranchState> BranchStates { get; set; }
        public List<CountryState> CountryStates { get; set; }
        public List<StateCity> StateCities { get; set; }
    }
}