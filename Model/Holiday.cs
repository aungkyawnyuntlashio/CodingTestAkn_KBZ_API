using System.ComponentModel.DataAnnotations;

namespace CodingTestAkn_KBZ_API.Model
{
    public class Holiday
    {
        public int Id { get; set; }
        [Required] public string? HolidayTitle { get; set; }
        [Required] public DateTime HolidayDate { get; set; }
    }
}
