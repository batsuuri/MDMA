using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMA.Core
{
    public class MIISEntity
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
        public class Vehicle
        {
            public string Color { get; set; }
            public int EngineCapacity { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public string Statenumber { get; set; }
            public double Payloadcapacity { get; set; }
            public string Rn { get; set; }
            public int Seatingcapacity { get; set; }
            public string Transporttype { get; set; }
            public string Vin { get; set; }
        }
    }
}
