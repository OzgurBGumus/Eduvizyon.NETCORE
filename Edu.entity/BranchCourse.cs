namespace Edu.entity
{
    public class BranchCourse
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}