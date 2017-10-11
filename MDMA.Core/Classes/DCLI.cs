using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDMA.Core
{
     public class DCLI
    {
        public Customer Driver { get; set; }
        public Vehicle Vehicle { get; set; }
        public Customer[] Drivers { get; set; }
        public bool IsLimitedDrivers { get; set; }

    }
}
