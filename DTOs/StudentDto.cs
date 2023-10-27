using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStudentManagementApp.DTOs
{
    public class StudentDto
    {
      public int StudentID { get; set; }
      public string FirstName { get; set; }  = string.Empty;
      public string LastName { get; set; } = string.Empty; 
      public DateTime BirthDate { get; set; } 
      public string Email { get; set; }  = string.Empty;
      public string Phone { get; set; }  = string.Empty;
    }
}