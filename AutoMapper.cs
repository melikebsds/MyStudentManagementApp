using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace MyStudentManagementApp
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<StudentDto, Student>();
            
            CreateMap<Attendance, AttendanceDto>();
            CreateMap<AttendanceDto, Attendance>();

            CreateMap<Grade, GradeDto>();
            CreateMap<GradeDto, Grade>();
        }
    }
}