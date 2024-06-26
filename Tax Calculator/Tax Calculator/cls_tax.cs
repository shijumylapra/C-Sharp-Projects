using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Code written by SHIJU ABRAHAM - 25TH JUNE 2024
namespace Tax_Calculator
{
    class cls_tax
    {
        public static bool IsWithin(double value, double minimum, double maximum)
        {
            return value >= minimum && value <= maximum;
        }
    }
}
