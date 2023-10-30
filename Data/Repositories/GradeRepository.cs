using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace MyStudentManagementApp.Data.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GradeRepository(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<GradeDto> CreateGradeAsync(Grade grade)
        {
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();
            return _mapper.Map<GradeDto>(grade);
        }

        public async Task<bool> DeleteGradeAsync(int id)
        {
            var existingGrade = await _context.Grades.FirstOrDefaultAsync(g => g.GradeID == id);
            if (existingGrade == null)
            {
                return false;
            }
            _context.Grades.Remove(existingGrade);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<GradeDto>> GetAllGradesAsync()
        {
            var grades = await _context.Grades.ToListAsync();
            /*
                        foreach (var item in grades)
            {
               var student = await _context.Students.FirstOrDefaultAsync(x => x.StudentID == item.StudentID);
            }
            */
            return _mapper.Map<List<GradeDto>>(grades);
        }

        public async Task<GradeDto> GetGradeByIdAsync(int id)
        {
            var grade = await _context.Grades.AsNoTracking().FirstOrDefaultAsync(g => g.GradeID == id);
            return _mapper.Map<GradeDto>(grade);
        }

        public async Task<GradeDto> UpdateGradeAsync(GradeDto grade)
        {
            var existingGrade = await _context.Grades.FirstOrDefaultAsync(g => g.GradeID == grade.GradeID);
            if (existingGrade == null)
            {
                return null;
            }
            _mapper.Map(grade, existingGrade);
            _context.Grades.Update(existingGrade);
            await _context.SaveChangesAsync();
            return _mapper.Map<GradeDto>(grade);
        }
    }
}