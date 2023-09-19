using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnSystemIO
{
    internal class Winner
    {

        public int _index { get; set; }
        public int _year { get; set; }
        public int _age {  get; set; }
        public string _name { get; set; }
        public string _movie {  get; set; }

        public Winner(string input)
        {
                      
            _index = int.Parse(input.Substring(0, 1));
            _year = int.Parse(input.Substring(3, 4));
            _age = int.Parse(input.Substring(9, 2));
            _name = input.Substring(14, input.IndexOf(',',14)-15);
            _movie = input.Substring((input.IndexOf(',', 14)+3), (-1+input.Length-(input.IndexOf(',', 14) + 3)));
 
        }


    }
}

