using CodingTestAkn_KBZ_API.DBContexts;
using CodingTestAkn_KBZ_API.Model;
using Microsoft.EntityFrameworkCore;

namespace CodingTestAkn_KBZ_API.Repository
{
    public class HolidayRepository : IHolidayRepository
    {
        private readonly DB_Contexts _dbContext;

        public HolidayRepository(DB_Contexts dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteHoliday(int holidayId)
        {
            var employee = _dbContext.Holidays.Find(holidayId);
            _dbContext.Holidays.Remove(employee);
            Save();
        }

        public Holiday FindHolidayByDate(DateTime holidayDate)
        {
            return _dbContext.Holidays.Where(h => h.HolidayDate == Convert.ToDateTime(holidayDate.ToString("yyyy-MM-dd"))).FirstOrDefault();
        }

        public IEnumerable<Holiday> GetAllHoliday()
        {
            return _dbContext.Holidays.ToList();
        }

        public Holiday GetHolidayByID(int holidayId)
        {
            return _dbContext.Holidays.Find(holidayId);
        }

        public void InsertHoliday(Holiday holiday)
        {
            _dbContext.Holidays.Add(holiday);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateHoliday(Holiday holiday)
        {
            _dbContext.Entry(holiday).State = EntityState.Modified;
            Save();
        }
    }
}
