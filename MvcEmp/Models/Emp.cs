using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcEmpDemo.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [Required(ErrorMessage = "Please Enter Employee Name")]
        public string EmpName { get; set; }
        [Required(ErrorMessage = "Please Enter City")]
        public string EmpCity { get; set; }
        [Required(ErrorMessage ="Please Enter Salary")]
        public int Salary { get; set; }
        [Required(ErrorMessage = "Please Select Gender")]
        public string Gender { get; set; }
    }
    public class EmpContext : DbContext
    {

        public DbSet <Employee> Employee { get; set; }

    }
}