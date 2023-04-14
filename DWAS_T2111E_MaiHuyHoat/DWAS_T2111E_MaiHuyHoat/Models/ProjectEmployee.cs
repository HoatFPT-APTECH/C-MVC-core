using System.ComponentModel.DataAnnotations;

namespace DWAS_T2111E_MaiHuyHoat.Models
{
    public class ProjectEmployee
    {
        [Required]
        public int  EmployeeId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public string Task { get; set; }
        public virtual Employee Employees { get; set; }
        public virtual Project Projects { get; set; }
    }
}
