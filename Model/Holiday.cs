using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingTestAkn_KBZ_API.Model
{
    public class Holiday
    {
        public int Id { get; set; }
        [Required] public string? HolidayTitle { get; set; }
        [Required] public DateTime HolidayDate { get; set; }
    }

    [NotMapped]
    public class HolidayDateModel { public DateTime HolidayDate { get; set; }}
}
