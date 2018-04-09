using GalaxyLibrary;
using GalaxyLibrary.DataMapping;
using GalaxyLibrary.Helpers;
using GalaxyLibrary.LanguageProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LanguageProcessor
{
  public  class ConcreteQueryFactory : QueryFactory
    {

        public IDataMappingHolder dataMappingHolder = null;

        public ConcreteQueryFactory(IDataMappingHolder _dataMappingHolder)
        {
            this.dataMappingHolder = _dataMappingHolder;
        }
        public override IQuery GetQueryType(string query)
        {
            var ParsedQuery = ParseQuery(query);
         
            if(ParsedQuery.QueryName== Constants.Querytype.DECLARATIONQUERY)
            {
                return new DeclarationQuery(query,ParsedQuery.queryConfiguration);
            }
            if (ParsedQuery.QueryName == Constants.Querytype.CALCULATIVEDECLARATIVEQUERY)
            {
                return new CalculativeDeclarativeQuery(query, ParsedQuery.queryConfiguration);
            }
            if (ParsedQuery.QueryName == Constants.Querytype.CREDITQUERY)
            {
                return new CreditQuery(query, ParsedQuery.queryConfiguration);
            }
            if (ParsedQuery.QueryName == Constants.Querytype.QUNATITIVEQUERY)
            {
                return new QunatitiveQuery(query, ParsedQuery.queryConfiguration);
            }
            else
            {
                throw new InValidQueryException(); 
            }
        }

        public  QueryEntity ParseQuery(string query)
        {
            QueryEntity _query = new QueryEntity();
            var queryConfiguratons= ConfigHelper.Instance.GetQueryConfiguration();
            foreach(var queryConfig in queryConfiguratons)
            {
                Regex regex = new Regex(queryConfig.RegEx);
                Match match = regex.Match(query);
                if (match.Success)
                {
                    _query.QueryName = queryConfig.Name;
                    _query.queryConfiguration = queryConfig;
                }
            }
            return _query;
        }

        //public string ProcessQuery(IQuery inputquery)
        //{
        //    string result = string.Empty;
        //    result=inputquery.ProcessQuery(dataMappingHolder);
        //    LoggerHelper.Instance.LogMapping(dataMappingHolder);
        //    return result;
        //}

    }
}
