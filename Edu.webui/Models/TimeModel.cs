using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Edu.entity;

namespace Edu.webui.Models
{
    public class TimeModel
    {
        public int TimeId { get; set; }
        [Required(ErrorMessage="Time Name is required.")]
        public string Name { get; set; }
        public List<int> CourseIds { get; set; }
    }
}