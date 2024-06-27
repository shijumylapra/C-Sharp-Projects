//CODE WRITTEN BY SHIJU ABRAHAM 27-09-24-
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDataLibrary
{
   public class ClCustomer
    {
        protected string path;
        protected string startup;
        public int cuscount;
        public double Total;
        public double csum;
        public double rsum;
        public double isum;
        //
        protected static string Ctype;

        //constructor for assign value 0 
        public ClCustomer()
        {
            cuscount =0;
            csum = 0;
            rsum = 0;
            isum = 0;
        }
        //Function to calculate total number of customers,
        public int customercount()
        {
            return cuscount++;
        }

        //Function for CalculateCharge 
        public string TotAmount(double amt1, double amt2, double amt3)
        {
            Total = (amt1 + amt2 + amt3);
            return Total.ToString("N2");
        }
        //Method for Customer Name UpperCase
        public static string Capitalize(string word)
        {
            return word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
            
        }
        //Child Class ResidentialCustomer for calculation Rsidential Customer Type
        public class ResidentialCustomer : ClCustomer
        {
            public double ResCustomer(double rcsum)
            {
                rsum += rcsum;
                return rsum;
            }

        }
        //Child Class CommercialCustomer for calculation Commerical Customer Type
        public class CommercialCustomer : ClCustomer
        {
            public double ComCustomer(double ccsum)
            {
                csum += ccsum;
                return csum;
            }
        }
        //Child Class IndustrialCustomer for calculation Industrial Customer Type
        public class IndustrialCustomer : ClCustomer
        {
            public double IndCustomer(double icsum)
            {
                isum += icsum;
                return isum;
            }
        }


        //connection Class Inherited from  Customer Class
        public class Connection : ClCustomer
        {
            public Connection(string _startup, string _path)
            {
                path = _path;
                startup = _startup;
            }
            public string fullpath
            {
                get
                {
                    return startup + path;
                }
            }

        }

    }

}
//CODE WRITTEN BY SHIJU ABRAHAM 27-09-24-