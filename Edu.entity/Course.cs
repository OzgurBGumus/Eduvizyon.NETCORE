using System.Collections.Generic;

namespace Edu.entity
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public int minAge { get; set; }
        public int LessonWeek { get; set; }
        public int HourWeek { get; set; }
        public int MaxStudent { get; set; }
        public string Level { get; set; }
        public double? PriceCourse { get; set; }
        public double? Discount { get; set; }
        public bool Active { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<CourseLanguage> CourseLanguage { get; set; }
        public List<CourseTime> CourseTime { get; set; }
        public List<BranchCourse> BranchCourse { get; set; }
    }
}