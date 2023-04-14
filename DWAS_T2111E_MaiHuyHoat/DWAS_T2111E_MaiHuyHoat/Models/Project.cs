using System.ComponentModel.DataAnnotations;

namespace DWAS_T2111E_MaiHuyHoat.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string ProjectName { get; set; } = "";
        [Required]
 
        public DateTime ProjectStartDate { get; set; }
        [Required]
        [Compare("ProjectStartDate", ErrorMessage = "Project end date must be greater than project start date.")]
        public DateTime? ProjectEndDate { get; set; }
    
        public virtual ICollection<ProjectEmployee> ProjectEmployees { get; set; }

    }
}
