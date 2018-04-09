using GalaxyLibrary;
using GalaxyLibrary.DataMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageProcessor
{
    class CalculativeDeclarativeQuery : AbstractQuery, IQuery
    {

        public CalculativeDeclarativeQuery(string _query, QueryConfiguration _queryConfiguration)
        {
            this.query = _query;
            this.QueryConfiguration = _queryConfiguration;
        }
        public string ProcessQuery(IDataMappingHolder _dataMappingHolder)
        {
           return this.ProcessQuery(_dataMappingHolder.RomanConstantsTable, _dataMappingHolder.DeclarativeCalculationTable);
        }
        public string ProcessQuery(Dictionary<string, RomanNumber> _romanConstantsTable, Dictionary<string, double> _DeclarativeCalculationTable)
        {
            StringBuilder result = new StringBuilder();

            /*
            A     B   Gold    is  100   Credits 
            0     1    2      3   4      5
            6-6  6-5  6-4        6-2
            

             A    B  C     Silver    is  100   Credits 
             0    1  2      3              4      5
            7-7  7-6 7-5   7-4            7-2 



            Length >=6

            <Qpart Name="CALCULATIVEDECLARATIVEQUERY"
                   ArrayLengthMinimum="6" 
                   ArrayKeyPartFromEnd="4" 
                   ArrayValuePartFromEnd="2" 
                   CalculativeIndexRangeStart="1" 
                   CalculativeIndexRangeEnd="-4"/>
            */

            var queryArry = this.query.Split(' ');
            var queryArryLength = queryArry.Length;

            string key = queryArry[queryArryLength - QueryConfiguration.KeyPosition];
            string value = queryArry[queryArryLength - QueryConfiguration.ValuePosition];
            int calStartIndex = QueryConfiguration.CalculativeStart - 1;
            int calEndIndex = Math.Abs(QueryConfiguration.CalculativeEnd);





            double credits = Convert.ToDouble(queryArry[queryArryLength-QueryConfiguration.ValuePosition]);
            StringBuilder romancontants = new StringBuilder();
            for (int i = calStartIndex; i <(queryArryLength - calEndIndex); i++)
            {
                var constant = queryArry[i];
                if (!_romanConstantsTable.ContainsKey(constant))
                {
                    throw new RomanMappingNotFoundException(constant);
                }

                RomanNumber romanNum;
                _romanConstantsTable.TryGetValue(constant, out romanNum);
                romancontants.Append(romanNum.RomanChar);
            }

            int ConstantValue = RomanProcessor.Instance.ConvertRomanToDecimal(romancontants.ToString());
            var KeyCalulcationValue = GetDelcarativeValue(credits, ConstantValue);

            if (!_DeclarativeCalculationTable.Keys.Contains(key))
            {
                _DeclarativeCalculationTable.Add(key, KeyCalulcationValue);
                LoggerHelper.Instance.LogConsole("Sucess!! Registered information.", Constants.MessageType.SUCCESS,false);
                LoggerHelper.Instance.LogConsole(query);
            }
            else
            {
                LoggerHelper.Instance.LogConsole("Warning !! same key found , overriding the key.", Constants.MessageType.WARNING);
                _DeclarativeCalculationTable.Remove(key);
                _DeclarativeCalculationTable.Add(key, KeyCalulcationValue);
                LoggerHelper.Instance.LogConsole("Sucess!! Registered information.", Constants.MessageType.SUCCESS,false);
                LoggerHelper.Instance.LogConsole(query);
            }

            return result.ToString();
        }

        private double GetDelcarativeValue(double _credits, int romanvalues)
        {
            return _credits / romanvalues;
        }
    }
}
