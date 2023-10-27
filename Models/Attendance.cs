using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStudentManagementApp.Models
{
    public class Attendance
    {
        [Key]
        public int StudentID { get; set; }
    }
}