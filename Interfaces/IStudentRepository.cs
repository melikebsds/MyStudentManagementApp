using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStudentManagementApp.DTOs;
using MyStudentManagementApp.Models;

namespace MyStudentManagementApp.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<StudentDto>> GetAllStudentsAsync();
        Task<StudentDto> GetStudentByIdAsync(int id);
        Task<StudentDto> CreateStudentAsync(Student student);
        Task<StudentDto> UpdateStudentAsync(int id, Student student);
        Task<bool> DeleteStudentAsync(int id);
    }
}