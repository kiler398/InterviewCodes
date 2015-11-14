using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoefficientLib
{
    [Serializable]
    public class CoefficientData
    {
        public string Province { get; set; }
        public string City { get; set; }
        public string Season { get; set; }
        public decimal Coefficient { get; set; }
    }
}
