using CodingTestAkn_KBZ_API.Model;
namespace CodingTestAkn_KBZ_API.Repository
{
    public interface IHolidayRepository
    {
        IEnumerable<Holiday> GetAllHoliday();

        Holiday GetHolidayByID(int holidayId);
        void InsertHoliday(Holiday holiday);
        void DeleteHoliday(int holidayId);
        void UpdateHoliday(Holiday holiday);
        void Save();
    }
}
