using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStudentManagementApp.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<List<AttendanceDto>> GetAllAttendancesAsync();
        Task<AttendanceDto> GetAttendanceByIdAsync(int id);
        Task<AttendanceDto> CreateAttendanceAsync(Attendance attendance);
        Task<AttendanceDto> UpdateAttendanceAsync(AttendanceDto attendance);
        Task<bool> DeleteAttendanceAsync(int id);
    }
}