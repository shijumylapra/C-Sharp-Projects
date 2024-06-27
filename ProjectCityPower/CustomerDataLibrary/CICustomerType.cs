//CODE WRITTEN BY SHIJU ABRAHAM 27-09-24-
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDataLibrary
{
    public class CICustomerType :ClCustomer
    {

        private string RCustomer = "Residential";
        private string CCustomer = "Commercial";
        private string ICustomer = "Industrial";

        //property to declare Customer Type selected value 
        public string CType
        {
            get => Ctype;
            set => Ctype = value;
        }

        public void TypeCt(string Val)
        {
            Ctype = Val;
        }

        //property to declare Customer Type to listview
        public string Type1
        {
            get
            {
                return RCustomer;
            }
            set
            {
                if (value == "Residential")
                {
                    RCustomer = value;
                }
            }
        }

        public string Type2
        {
            get
            {
                return CCustomer;
            }
            set
            {
                if (value == "Commercial")
                {
                    CCustomer = value;
                }
            }
        }
        public string Type3
        {
            get
            {
                return ICustomer;
            }
            set
            {
                if (value == "Industrial")
                {
                    ICustomer = value;
                }
            }
        }
    }
}
//CODE WRITTEN BY SHIJU ABRAHAM 27-09-24-