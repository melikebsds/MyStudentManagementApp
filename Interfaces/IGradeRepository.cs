using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStudentManagementApp.Interfaces
{
    public interface IGradeRepository
    {
        Task<List<GradeDto>> GetAllGradesAsync();
        Task<GradeDto> GetGradeByIdAsync(int id);
        Task<GradeDto> CreateGradeAsync(Grade grade);
        Task<GradeDto> UpdateGradeAsync(GradeDto grade);
        Task<bool> DeleteGradeAsync(int id);
    }
}