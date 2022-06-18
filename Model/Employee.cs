using System.ComponentModel.DataAnnotations;

namespace CodingTestAkn_KBZ_API.Model
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string? EmployeeName { get; set; }
        [Required]
        public string? EmployeeCode { get; set; }
        [Required]
        public string? Mobile { get; set; }
        [Required]
        public DateTime JoinDate { get; set; }
        [Required]
        public string? Designation { get; set; }
        [Required]
        public string? Department { get; set; }
        public string? Address { get; set; }
        [Required]
        public int BasicSalary { get; set; }
    }
}
