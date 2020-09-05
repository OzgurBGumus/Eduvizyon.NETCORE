using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Edu.entity;

namespace Edu.webui.Models
{
    public class SchoolModel
    {
        public int SchoolId { get; set; }
        
        [Display(Name="Name", Prompt="Enter School Name")]
        [Required(ErrorMessage="School Name is required.")]
        public string Name { get; set; }

        [Display(Name="Url", Prompt="School URL")]
        [Required(ErrorMessage="School Url Is Required")]
        public string Url { get; set; }

        [Display(Name="LogoUrl", Prompt="Enter School LogoUrl")]
        public string LogoUrl { get; set; }

        [Display(Name="Description", Prompt="Enter School Description")]
        [Required(ErrorMessage="School Description is required.")]
        public string Description { get; set; }
        
        [Display(Name="active", Prompt="active")]
        public bool active { get; set; }
        public List<int> BranchIds { get; set; }
        public List<int> SImageIds { get; set; }
    }
}