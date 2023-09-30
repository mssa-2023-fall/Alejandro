using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
   
    
    public class ClockDegree
    {
        
        public double Minutes { get; set; }
        public double Hours { get; set; }
        public double DegreeMinutes { get; set; }
        public double DegreeHours { get; set; }
        public ClockDegree()
            { }
        public double GetDegreeMinutes()
            { DegreeMinutes = Minutes * 6; return DegreeMinutes; }
        public double GetDegreeHours()
            { DegreeHours = Hours * 30; return DegreeHours;}
        public double GetDegreeGivenTime(double Hour, double Minute)
            {
                Hours = Hour;
                Minutes = Minute;
                GetDegreeHours();
                GetDegreeMinutes();
                double result = 0;
                double degreeDiff = DegreeMinutes - DegreeHours;

                //checking for the outer degree and inner degree in case hands are on opposing halves and not at a 180 degrees.
            
                if (degreeDiff > 180 || degreeDiff < -180)
                {
                    result = degreeDiff < 0 ? 360 - (degreeDiff * (-1)) : 360 - degreeDiff;
                }
                else { result = degreeDiff; }


                //Returning the absolute value of result
                return result < 0 ? (double)result * (-1) : result;
            }

    }
}


