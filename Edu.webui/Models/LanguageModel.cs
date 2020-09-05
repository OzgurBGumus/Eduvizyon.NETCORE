using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Edu.entity;

namespace Edu.webui.Models
{
    public class LanguageModel
    {
        public int LanguageId { get; set; }
        [Required(ErrorMessage="Language Name is required.")]
        [Display(Name="Name", Prompt="Enter Language Name")]
        public string Name { get; set; }
        public List<int> CourseIds { get; set; }
    }
}