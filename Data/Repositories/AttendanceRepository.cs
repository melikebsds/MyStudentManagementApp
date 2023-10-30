using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace MyStudentManagementApp.Data.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public AttendanceRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            
        }
        public async Task<AttendanceDto> CreateAttendanceAsync(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();
            return _mapper.Map<AttendanceDto>(attendance);
        }

        public async Task<bool> DeleteAttendanceAsync(int id)
        {
            var existingAttendance = await _context.Attendances.FirstOrDefaultAsync(a => a.AttendanceID == id);
            if (existingAttendance == null)
            {
                return false;
            }
            _context.Attendances.Remove(existingAttendance);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<AttendanceDto>> GetAllAttendancesAsync()
        {
            var attendances = await _context.Attendances.ToListAsync();
            return _mapper.Map<List<AttendanceDto>>(attendances);
        }

        public async Task<AttendanceDto> GetAttendanceByIdAsync(int id)
        {
            var attendance = await _context.Attendances.AsNoTracking().FirstOrDefaultAsync(a => a.AttendanceID == id);
            return _mapper.Map<AttendanceDto>(attendance);
        }

        public async Task<AttendanceDto> UpdateAttendanceAsync(AttendanceDto attendance)
        {
            var existingAttendance = await _context.Attendances.FirstOrDefaultAsync(a => a.AttendanceID == attendance.AttendanceID);
            if (existingAttendance == null)
            {
                return null;
            }
            _mapper.Map(attendance, existingAttendance);
            _context.Attendances.Update(existingAttendance);
            await _context.SaveChangesAsync();
            return _mapper.Map<AttendanceDto>(attendance);
        }
    }
}