using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStudentManagementApp.DTOs;
using MyStudentManagementApp.Interfaces;
using MyStudentManagementApp.Models;

namespace MyStudentManagementApp.Controllers
{
    [Route("api/students")] // Route belirtilmelidir.
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentDto>>> GetAllStudents()
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudentById(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> CreateStudent(Student student)
        {
            var createdStudent = await _studentRepository.CreateStudentAsync(student);
            //bu satırlar CreatedAtAction fonksiyonun anlamak için daha açıklayıcı
            //var actionName = nameof(GetStudentById);
            //var routeValues = new { id = createdStudent.StudentID };
            //return CreatedAtAction(actionName, routeValues, createdStudent);
            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudent.StudentID }, createdStudent);
        }

        [HttpPut]
        public async Task<ActionResult<StudentDto>> UpdateStudent([FromBody] StudentDto student)
        {

            var updatedStudent = await _studentRepository.UpdateStudentAsync(student);
            if (updatedStudent == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var result = await _studentRepository.DeleteStudentAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}