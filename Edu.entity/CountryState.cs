namespace Edu.entity
{
    public class CountryState
    {
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
    }
}