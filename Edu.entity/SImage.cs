using System.Collections.Generic;

namespace Edu.entity
{
    public class SImage
    {
        public int SImageId { get; set; }
        public string Url { get; set; }
        public bool IsDeleted { get; set; }
        public List<SchoolSImage> SchoolSImage { get; set; }
    }
}