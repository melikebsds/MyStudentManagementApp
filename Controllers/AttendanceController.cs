using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyStudentManagementApp.Controllers
{
    [Route("api/attendances")] // Route belirtilmelidir.
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepository _attendanceRepository;
        public AttendanceController(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
            
        }
        [HttpGet]
        public async Task<ActionResult<List<AttendanceDto>>>GetAllAttendances()
        {
            var attendances = await _attendanceRepository.GetAllAttendancesAsync();
            return Ok(attendances);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceDto>>GetAttendanceById(int id)
        {
            var attendance = await _attendanceRepository.GetAttendanceByIdAsync(id);
            if(attendance == null)
            {
                return NotFound();
            }
            return Ok(attendance);
        }
        [HttpDelete]
        public async Task<ActionResult>DeleteAttendance(int id)
        {
            var result = await _attendanceRepository.DeleteAttendanceAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<AttendanceDto>> CreateAttendance(Attendance attendance)
        {
            var createdAttendance = await _attendanceRepository.CreateAttendanceAsync(attendance);
            return CreatedAtAction(nameof(GetAttendanceById), new { id = createdAttendance.AttendanceID }, createdAttendance);
        }
        [HttpPut]
        public async Task<ActionResult<AttendanceDto>> UpdateAttendance([FromBody] AttendanceDto attendance)
        {
            var updateAttendance = await _attendanceRepository.UpdateAttendanceAsync(attendance);
            if (updateAttendance == null)
            {
                return NotFound();
            }
            return Ok(attendance);
        }
    }
}