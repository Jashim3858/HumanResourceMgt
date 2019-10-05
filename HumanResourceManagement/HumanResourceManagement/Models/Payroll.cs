using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanResourceManagement.Models
{
    public class Payroll
    {
        public int PayrollID { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal OverTime { get; set; }
        public decimal HouserentAllowance { get; set; }
        public decimal TransportAllowance { get; set; }
        public decimal DarenessAllowance { get; set; }
        public decimal MedicalAllowance { get; set; }
        public decimal GrossSalary { get; set; }
        public decimal ProvidentFund { get; set; }
        public decimal CashAdvanced { get; set; }
        public decimal ToatalDeduction { get; set; }
        public decimal NetSalary { get; set; }

        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }


    }
}