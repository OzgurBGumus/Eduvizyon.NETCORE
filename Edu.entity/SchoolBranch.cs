namespace Edu.entity
{
    public class SchoolBranch
    {
        public int SchoolId { get; set; }
        public School School { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}