using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyStudentManagementApp.Controllers
{
    [Route("api/grades")] // Route belirtilmelidir.
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeRepository _gradeRepository;
        public GradeController(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<GradeDto>>> GetAllGrades()
        {
            var grades = await _gradeRepository.GetAllGradesAsync();
            return Ok(grades);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GradeDto>>GetGradeById(int id)
        {
            var grade = await _gradeRepository.GetGradeByIdAsync(id);
            if(grade == null)
            {
                return NotFound();
            }
            return Ok(grade);
        }
        [HttpDelete]
        public async Task<ActionResult>DeleteGrade(int id)
        {
            var result = await _gradeRepository.DeleteGradeAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<GradeDto>> CreateGrade(Grade grade)
        {
            var createdGrade = await _gradeRepository.CreateGradeAsync(grade);
            return CreatedAtAction(nameof(GetGradeById), new { id = createdGrade.GradeID }, createdGrade);
        }
        [HttpPut]
        public async Task<ActionResult<GradeDto>> UpdateGrade([FromBody] GradeDto grade)
        {
            var updateGrade = await _gradeRepository.UpdateGradeAsync(grade);
            if (updateGrade == null)
            {
                return NotFound();
            }
            return Ok(grade);
        }
    }
}