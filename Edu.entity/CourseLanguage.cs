namespace Edu.entity
{
    public class CourseLanguage
    {
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}