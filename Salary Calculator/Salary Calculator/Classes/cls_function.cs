using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary_Calculator.Classes
{
    class cls_function
    {
        public static double stpay;
        public static double otpay;
        public static double totpay;



        public static string Calculations(string othrs, string amount, string rghrs)
        {
            stpay = 0; otpay = 0; totpay = 0;
            if (Convert.ToDouble(othrs) > 0)
            {
                otpay = Math.Abs((Convert.ToDouble(othrs) * 1.5) * Convert.ToDouble(amount));
                stpay = Math.Abs(Convert.ToDouble(Convert.ToDouble(rghrs) * Convert.ToDouble(amount)));
                totpay = (stpay + otpay);
                return null;
            }
            else
            {
                stpay = Math.Abs(Convert.ToDouble(Convert.ToDouble(rghrs) * Convert.ToDouble(amount)));
                totpay = stpay;
                return null;
            }

        }

    }
}
