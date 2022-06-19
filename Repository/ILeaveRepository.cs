using CodingTestAkn_KBZ_API.Model;

namespace CodingTestAkn_KBZ_API.Repository
{
    public interface ILeaveRepository
    {
        IEnumerable<LeaveViewModel> GetAllLeave();

        LeaveViewModel GetLeaveByID(int leaveId);
        void InsertLeave(Leave leave);
        void DeleteLeave(int leaveId);
        void UpdateLeave(Leave leave);
        void Save();
    }
}
