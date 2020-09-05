using System.Collections.Generic;

namespace Edu.entity
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<CourseLanguage> CourseLanguages { get; set; }
    }
}