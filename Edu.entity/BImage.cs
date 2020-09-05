using System.Collections.Generic;

namespace Edu.entity
{
    public class BImage
    {
        public int BImageId { get; set; }
        public string Url { get; set; }
        public bool IsDeleted { get; set; }
        public List<BranchBImage> BranchImage { get; set; }
    }
}