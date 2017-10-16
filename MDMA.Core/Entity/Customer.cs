using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDMA
{
    public class Customer
    {
        public string Address { get; set; }
        public string DLN { get; set; }
        public string Email { get; set; }
        public int Experience { get; set; }
        public string FamilyName { get; set; }
        public int PGroup { get; set; }
        public string PNumAmends { get; set; }
        public string Phone { get; set; }
        public string Rn { get; set; }
        public bool IsOrg { get; set; }
        public double Age { get; set; }
        public int? ZipCode { get; set; }
    }
}