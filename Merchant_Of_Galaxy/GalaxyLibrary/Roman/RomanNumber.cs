using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace GalaxyLibrary
{
   public class RomanNumber
    {
        
        public char RomanChar { get; set; }
        public int DecimalValue { get; set; }


        public RomanNumber()
        {

        }
        public RomanNumber(char _RomanChar)
        {
            this.RomanChar = _RomanChar;
            this.DecimalValue = RomanProcessor.Instance.ConvertRomanToDecimal(_RomanChar.ToString());
        }
        public RomanNumber(char _RomanChar,int _DecimalValue)
        {
            this.RomanChar = _RomanChar;
            this.DecimalValue = _DecimalValue;
        }

    }


}
