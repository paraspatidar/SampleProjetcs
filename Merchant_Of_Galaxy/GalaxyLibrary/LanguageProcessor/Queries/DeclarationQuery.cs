using GalaxyLibrary;
using GalaxyLibrary.DataMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageProcessor
{
    class DeclarationQuery :AbstractQuery, IQuery
    {
        public DeclarationQuery(string _query,QueryConfiguration _queryconfigurtion)
        {
            this.query = _query;
            this.QueryConfiguration=_queryconfigurtion;


        }

        public string ProcessQuery(IDataMappingHolder _dataMappingHolder)
        {
           return this.ProcessQuery(_dataMappingHolder.RomanConstantsTable, _dataMappingHolder.DeclarativeCalculationTable);
        }

        public string ProcessQuery(Dictionary<string, RomanNumber> _romanConstantsTable , Dictionary<string, double> _DeclarativeCalculationTable)
        {
            StringBuilder result = new StringBuilder();
            /*
            A is I
            0 1  2
            Length =3

            <Qpart Name="DECLARATIONQUERY" 
                ArrayLengthMinimum="3" 
                ArrayKeyPartFromEnd="3" 
                ArrayValuePartFromEnd="1"/>
            */

            var queryArry = this.query.Split(' ');
            var queryArryLength = queryArry.Length;

            string key = queryArry[queryArryLength-QueryConfiguration.KeyPosition];
            string value = queryArry[queryArryLength-QueryConfiguration.ValuePosition];

            if (!_romanConstantsTable.Keys.Contains(key))
            {
                _romanConstantsTable.Add(key, new RomanNumber(Convert.ToChar(value)));
                LoggerHelper.Instance.LogConsole("Sucess!! Registered information.", Constants.MessageType.SUCCESS,false);
                LoggerHelper.Instance.LogConsole(query);
            }
            else
            {
                LoggerHelper.Instance.LogConsole("Warning !! same key found , overriding the key.", Constants.MessageType.WARNING);
                _romanConstantsTable.Remove(key);
                _romanConstantsTable.Add(key, new RomanNumber(Convert.ToChar(value)));
                LoggerHelper.Instance.LogConsole("Sucess!! Registered information.", Constants.MessageType.SUCCESS,false);
                LoggerHelper.Instance.LogConsole(query);
            }

            return result.ToString();
        }
    }
}
 