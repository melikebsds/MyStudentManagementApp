using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

using MyStudentManagementApp.Models;

namespace MyStudentManagementApp.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public StudentRepository(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<StudentDto>> GetAllStudentsAsync()
        {
            var students = await _context.Students.ToListAsync();            
            return _mapper.Map<List<StudentDto>>(students);
        }
        
        public async Task<StudentDto> GetStudentByIdAsync(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentID == id);
            return _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> CreateStudentAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return _mapper.Map<StudentDto>(student);
        }
        
        public async Task<StudentDto> UpdateStudentAsync(int id, Student student)
        {
            var existingStudent = await _context.Students.FirstOrDefaultAsync(s => s.StudentID == id);
            if (existingStudent == null)
            {
                return null;
            }

            _mapper.Map(student, existingStudent);

            await _context.SaveChangesAsync();

            return _mapper.Map<StudentDto>(existingStudent);
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var existingStudent = await _context.Students.FirstOrDefaultAsync(s => s.StudentID == id);
            if (existingStudent == null)
            {
                return false;
            }

            _context.Students.Remove(existingStudent);
            await _context.SaveChangesAsync();

            return true;
        }     

        
    }

}