using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCRUDOperation.Models
{
    public class TestEmployee
    {


        [Required(ErrorMessage = "No is Required")]
        public int Eno { get; set; }

        [Required(ErrorMessage = "Name field is Required")]
        public string Ename { get; set; }

        [Required(ErrorMessage = "Please enter salary field")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Please enter Job field")]
        public string Job { get; set; }

        [Required(ErrorMessage = "Please enter Dept field")]
        public string Dname { get; set; }


       // public List<Employee> EmpList { get; set; }

    }
}