using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HumanResourceManagement.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public string StreetAddress { get; set; }
        public int PoastalCode { get; set; }
        public string City { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Department> Departments { get; set; }

    }
}