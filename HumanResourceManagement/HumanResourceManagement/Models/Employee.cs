using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HumanResourceManagement.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public DateTime DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string ContractAddress { get; set; }
        public int BasicSalary { get; set; }
        public DateTime HireDate { get; set; }

        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }

        public string PicUrl { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }

        public virtual ICollection<Payroll> Payrolls { get; set; }

    }
}