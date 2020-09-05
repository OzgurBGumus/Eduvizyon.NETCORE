namespace Edu.entity
{
    public class SchoolSImage
    {
        public int SImageId { get; set; }
        public SImage SImage { get; set; }
        public int SchoolId { get; set; }
        public School School { get; set; }
    }
}