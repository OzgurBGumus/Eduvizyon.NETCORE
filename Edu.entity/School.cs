using System.Collections.Generic;

namespace Edu.entity
{
    public class School
    {
        public int SchoolId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string LogoUrl { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public List<SchoolSImage> SchoolSImages { get; set; }
        public List<SchoolBranch> SchoolBranches { get; set; }
        public bool active { get; set; }
    }
}