using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingTestAkn_KBZ_API.Model
{
    public class Leave
    {
        public int Id { get; set; }
        [Required] public string? LeaveCode { get; set; }
        [Required] public int EmployeeId { get; set; }
        [Required] public string? Purpose { get; set; }
        [Required] public DateTime StartDate { get; set; }
        [Required] public DateTime EndDate { get; set; }
        [Required] public int NumOfDay { get; set; }
    }

    [NotMapped]
    public class LeaveViewModel
    {
        public int Id { get; set; }
        public string? LeaveCode { get; set; }
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeCode { get; set; }
        public string? Purpose { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public int NumOfDay { get; set; }
    }
}
