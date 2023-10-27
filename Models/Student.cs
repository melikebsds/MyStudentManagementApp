using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyStudentManagementApp.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        
        [Required]
        public string FirstName { get; set; }  = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty; 
        public DateTime BirthDate { get; set; } 

        [Required]
        [EmailAddress]
        public string Email { get; set; }  = string.Empty;

        [Phone]
        public string Phone { get; set; }  = string.Empty;
    }
}