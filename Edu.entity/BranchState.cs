namespace Edu.entity
{
    public class BranchState
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
    }
}