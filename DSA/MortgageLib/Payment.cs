using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageLib
{
    public class Payment 
    {
        
        public double PrincipalPaid {  get; set; }
        public double InterestPaid { get; set; }
        public double RemainingBalance { get; set; }
        public DateTime PaymentDate { get; set; }


        public Payment() 
        {   
            

        }
    }
}
