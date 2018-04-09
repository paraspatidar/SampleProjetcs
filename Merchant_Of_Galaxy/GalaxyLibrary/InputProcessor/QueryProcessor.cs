using GalaxyLibrary.Unity;
using LanguageProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace GalaxyLibrary
{
   public class QueryProcessor : IQueryProcessor
    {

       public ConcreteQueryFactory oConcreteQueryFactory = null;
        IUnityContainer container = DependencyResolver.DependencyRegiration();
        public QueryProcessor()
        {
            
            oConcreteQueryFactory = container.Resolve<ConcreteQueryFactory>();
        }
        public string ProcessQuery(string query)
        {
            try
            {

                IQuery oQuery = oConcreteQueryFactory.GetQueryType(query);
                var responce= oQuery.ProcessQuery(oConcreteQueryFactory.dataMappingHolder);
                LoggerHelper.Instance.LogMapping(oConcreteQueryFactory.dataMappingHolder);
                return responce;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
