using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStudentManagementApp.Models
{
    public class Grade
    {
        [Key]
        public int GradeID { get; set; }
        public int StudentID { get; set; }
        public decimal Score { get; set; }
    }
}