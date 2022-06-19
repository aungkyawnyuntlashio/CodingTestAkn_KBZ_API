using CodingTestAkn_KBZ_API.DBContexts;
using CodingTestAkn_KBZ_API.Model;
using Microsoft.EntityFrameworkCore;

namespace CodingTestAkn_KBZ_API.Repository
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly DB_Contexts _dbContext;

        public LeaveRepository(DB_Contexts dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteLeave(int leaveId)
        {
            var leave = _dbContext.Leaves.Find(leaveId);
            _dbContext.Leaves.Remove(leave);
            Save();
        }

        public IEnumerable<LeaveViewModel> GetAllLeave()
        {
            var result = (from l in _dbContext.Leaves
                          join e in _dbContext.Employees
                          on l.EmployeeId equals e.Id
                          select new LeaveViewModel
                          {
                              Id=l.Id,
                              LeaveCode = l.LeaveCode,
                              EmployeeId=l.EmployeeId,
                              EmployeeName=e.EmployeeName,
                              EmployeeCode=e.EmployeeCode,
                              Purpose=l.Purpose,
                              StartDate=l.StartDate.ToString("yyyy-MM-dd"),
                              EndDate=l.EndDate.ToString("yyyy-MM-dd"),
                              NumOfDay=l.NumOfDay,
                          }
                        ).ToList();
            return result;
        }

        public LeaveViewModel GetLeaveByID(int leaveId)
        {
            var result = (from l in _dbContext.Leaves
                          join e in _dbContext.Employees
                          on l.EmployeeId equals e.Id
                          where l.Id == leaveId
                          select new LeaveViewModel
                          {
                              Id = l.Id,
                              LeaveCode = l.LeaveCode,
                              EmployeeId = l.EmployeeId,
                              EmployeeName = e.EmployeeName,
                              EmployeeCode = e.EmployeeCode,
                              Purpose = l.Purpose,
                              StartDate = l.StartDate.ToString("yyyy-MM-dd"),
                              EndDate = l.EndDate.ToString("yyyy-MM-dd"),
                              NumOfDay = l.NumOfDay,
                          }
                        ).FirstOrDefault();
            return result;
        }

        public void InsertLeave(Leave leave)
        {
            _dbContext.Leaves.Add(leave);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateLeave(Leave leave)
        {
            _dbContext.Entry(leave).State = EntityState.Modified;
            Save();
        }
    }
}
