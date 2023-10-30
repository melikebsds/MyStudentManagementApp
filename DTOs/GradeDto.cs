using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyStudentManagementApp.DTOs
{
    public class GradeDto
    {
        public int GradeID { get; set; }
        public int StudentID { get; set; }
    //    public Student Student {get; set;}
        public decimal Score { get; set;}

//        [NotMapped]
  //      public string StudentName {get; set;} = String.Empty;
    }
}