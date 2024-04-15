using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CRUD.Models
{
    public class Emp_Model
    {
        [Required]
        [DisplayName("Emp Id")]
        public int Empid { get; set; }

        [Required]
        [DisplayName("Emp Name")]
        public string EmpName { get; set; }

        [Required]
        [DisplayName("Emp Department")]
        public string EmpDept { get; set; }
    }
}