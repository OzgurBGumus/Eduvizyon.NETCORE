namespace Edu.entity
{
    public class CourseTime
    {
        public int TimeId { get; set; }
        public Time Time { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}