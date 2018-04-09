using GalaxyLibrary;
using GalaxyLibrary.DataMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageProcessor
{
    class QunatitiveQuery :AbstractQuery, IQuery
    {
        public QunatitiveQuery(string _query, QueryConfiguration _queryConfiguration)
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
          how much is       A       A       C       D   ?
          0     1    2      3       4       5      6    7   
          8-8  8-7  8-6     8-5    8-4     8-3    8-2   8-1


          how much is       A       A       C       D   F   ?
           0    1   2      3     4    5     6      7     8
          9-9              9-6   9-5   9-4   9-3    9-2   9-1 



          Length >=8

          <Qpart Name="QUNATITIVEQUERY" 
                ArrayLengthMinimum="8" 
                CalculativeIndexRangeStart="4" 
                CalculativeIndexRangeEnd="1"/>
          */

            var queryArry = this.query.Split(' ');
            var queryArryLength = queryArry.Length;

                       
            int calStartIndex = QueryConfiguration.CalculativeStart - 1;
            int calEndIndex = Math.Abs(QueryConfiguration.CalculativeEnd);



            StringBuilder romancontants = new StringBuilder();
            for (int i = calStartIndex; i < (queryArryLength - calEndIndex); i++)
            {
                var constant = queryArry[i];

                if (!_romanConstantsTable.ContainsKey(constant))
                {
                    throw new RomanMappingNotFoundException(constant);
                }  

                RomanNumber romanNum;
                _romanConstantsTable.TryGetValue(constant, out romanNum);
                romancontants.Append(romanNum.RomanChar);

                //append it for result as well to show output like : A B C  , then will add :is XX 
                result.Append(constant + " ");
            }

            int ConstantValue = RomanProcessor.Instance.ConvertRomanToDecimal(romancontants.ToString());

            //LoggerHelper.Instance.LogConsole("Sucess!! Result for Query :" + query, Constants.MessageType.SUCCESS);
            //LoggerHelper.Instance.LogConsole(ConstantValue.ToString(), Constants.MessageType.SUCCESS);

            //LoggerHelper.Instance.LogConsole(query);

            result.Append("is " + ConstantValue );

            return result.ToString();
        }
    }
}
