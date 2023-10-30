using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStudentManagementApp.DTOs
{
    public class AttendanceDto
    {
        public int AttendanceID { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }
    }
}