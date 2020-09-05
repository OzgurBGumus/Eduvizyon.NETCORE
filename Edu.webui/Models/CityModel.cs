using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Edu.entity;

namespace Edu.webui.Models
{
    public class CityModel
    {
        public int CityId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        public bool Active { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public List<int> BranchIds { get; set; }
    }
}