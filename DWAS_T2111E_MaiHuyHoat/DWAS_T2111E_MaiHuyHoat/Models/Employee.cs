using System.ComponentModel.DataAnnotations;

namespace DWAS_T2111E_MaiHuyHoat.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string EmployeeName { get; set; } = "";
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1/1/1900", "12/31/2005", ErrorMessage = "Employee must be over 16 years old.")]
        public DateTime EmployeeDOB { get; set; }= DateTime.Now;
        [Required]
        public string EmployeeDepartment { get; set; }
        public virtual ICollection<ProjectEmployee> EmployeeProjects { get; set; }

    }
}
