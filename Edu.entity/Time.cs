using System.Collections.Generic;

namespace Edu.entity
{
    public class Time
    {
        public int TimeId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<CourseTime> CourseTimes { get; set; }
    }
}