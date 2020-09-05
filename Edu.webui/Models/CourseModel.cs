using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Edu.entity;

namespace Edu.webui.Models
{
    public class CourseModel
    {
        public int CourseId { get; set; }

        [Required(ErrorMessage="Course Name is required.")]
        [Display(Name="Name", Prompt="Enter Course Name")]
        public string Name { get; set; }

        [Display(Name="Url", Prompt="Course URL")]
        [Required(ErrorMessage="Course Url Is Required")]
        public string Url { get; set; }

        [Display(Name="Description", Prompt="Enter Course Description")]
        [Required(ErrorMessage="Course Description is required.")]
        public string Description { get; set; }

        [Display(Name="minAge", Prompt="Enter Course minAge")]
        [Required(ErrorMessage="Course minAge is required.")]
        [Range(1,100,ErrorMessage="Age must be between {1} and {2}.")]
        public int minAge { get; set; }

        [Display(Name="LessonWeek", Prompt="Enter Course LessonWeek")]
        [Required(ErrorMessage="Course LessonWeek is required.")]
        [Range(1,200,ErrorMessage="Lesson Per Week must be between {1} and {2}.")]
        public int LessonWeek { get; set; }

        [Display(Name="HourWeek", Prompt="Enter Course HourWeek")]
        [Required(ErrorMessage="Course HourWeek is required.")]
        [Range(1,200,ErrorMessage="Hour Per Week must be between {1} and {2}.")]
        public int HourWeek { get; set; }

        [Display(Name="MaxStudent", Prompt="Enter Course MaxStudent")]
        [Required(ErrorMessage="Course MaxStudent is required.")]
        [Range(1,1000,ErrorMessage="Max must be between {1} and {2}.")]
        public int MaxStudent { get; set; }

        [Display(Name="Level", Prompt="Enter Course Level")]
        [Required(ErrorMessage="Course Level is required.")]
        [StringLength(30,MinimumLength=1,ErrorMessage="Course Level length Should Be Between 5-30")]
        public string Level { get; set; }
        [Display(Name="PriceCourse", Prompt="Enter Course PriceCourse")]
        [Required(ErrorMessage="Course PriceCourse is required.")]
        [Range(1,1000000,ErrorMessage="Price must be between {1} and {2}.")]
        public int PriceCourse { get; set; }

        [Display(Name="Discount", Prompt="Enter Course Discount")]
        [Range(1,100)]  
        public int? Discount { get; set; }

        [Required(ErrorMessage="Active is required. (If You Get this, there is something wrong.)")]
        [Display(Name="Active", Prompt="Enter Coyrse Active (If You Get this, there is something wrong.)")]
        public bool Active { get; set; }
        [Display(Name="StartDate", Prompt="Enter Course StartDate")]
        [Required(ErrorMessage="Course StartDate is required.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string StartDate { get; set; }
        [Display(Name="EndDate", Prompt="Enter Course EndDate")]
        [Required(ErrorMessage="Course EndDate is required.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public string EndDate { get; set; }
        [Display(Name="Language", Prompt="Enter Course Language")]
        [Required(ErrorMessage="Course Language is required.")]
        public int? LanguageId { get; set; }
        [Display(Name="Time", Prompt="Enter Course Time")]
        [Required(ErrorMessage="Course Time is required.")]
        public int? TimeId { get; set; }
        [Display(Name="School", Prompt="Enter Course School")]
        [Required(ErrorMessage="Course School is required.")]
        public int BranchId { get; set; }
    }
}