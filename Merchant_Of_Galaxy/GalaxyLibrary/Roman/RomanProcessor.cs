using GalaxyLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyLibrary
{
    public sealed class RomanProcessor
    {
        public readonly List<RomanNumber> romanNumbers = null;
        private static readonly Lazy<RomanProcessor> lazy =
         new Lazy<RomanProcessor>(() => new RomanProcessor());

        public static RomanProcessor Instance { get { return lazy.Value; } }

        private RomanProcessor()
        {
            romanNumbers = GetConfigurationUsingSection();
        }

        public List<RomanNumber> RomanNumberCollection()
        {
            //Not values mentioned in question contains wrong value for L , L is 50 , not 250
            return romanNumbers;

        }
        private List<RomanNumber> GetConfigurationUsingSection()
        {
            List<RomanNumber> _romanNumbers = new List<RomanNumber>();
            var applicationSettings = ConfigurationManager.GetSection("RomanNumbers") as NameValueCollection;
            if (applicationSettings.Count == 0)
            {
                Console.WriteLine("Application Settings are not defined");
            }
            else
            {
                foreach (var key in applicationSettings.AllKeys)
                {
                    //Console.WriteLine(key + " = " + applicationSettings[key]);
                    _romanNumbers.Add(new RomanNumber() { RomanChar = Convert.ToChar(key), DecimalValue = int.Parse(applicationSettings[key]) });
                }
            }

            return _romanNumbers;
        }

        public int ConvertRomanToDecimal(string romanNumber)
        {
            if (!IsValidRoman(romanNumber))
                throw new InvalidRomanNumberException();

            var Decimalvalues = romanNumber.Select(GetDecimal).Reverse().ToArray();
            var result = 0;
            var currentValue = 0;
            var previousValue = 0;

            for (var i = 0; i < Decimalvalues.Length; i++)
            {
                currentValue = Decimalvalues[i];
                currentValue = previousValue > currentValue ? -currentValue : currentValue;
                result += currentValue;
                previousValue = currentValue;
            }

            return result;
        }

        private int GetDecimal(char _romanChar)
        {
            return romanNumbers.Where(v => v.RomanChar == _romanChar).FirstOrDefault().DecimalValue;
        }

        private bool IsValidRoman(string romanNumber)
        {
            if (!romanNumber.All(x => romanNumbers.Select(n=>n.RomanChar).Contains(x)))
            {
                return false;
            }
            else
                return true;
        }
    }
}
