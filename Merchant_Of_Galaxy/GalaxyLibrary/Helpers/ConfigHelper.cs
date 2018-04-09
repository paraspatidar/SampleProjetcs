using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using GalaxyLibrary.Exceptions;


namespace GalaxyLibrary.Helpers
{

    public sealed class ConfigHelper
    {
        private  List<QueryConfiguration> queryConfiguration = null;
        private static readonly Lazy<ConfigHelper> lazy =
         new Lazy<ConfigHelper>(() => new ConfigHelper());

        public static ConfigHelper Instance { get { return lazy.Value; } }

        private ConfigHelper()
        {

        }

        public List<QueryConfiguration> GetQueryRegEx()
        {
            List<QueryConfiguration> _listQueryConfig = new List<QueryConfiguration>();

            XmlDocument xml = new XmlDocument();
            string QueryFileLocation = File.Exists("Queryconfig.xml") ? "Queryconfig.xml" :
                                        (File.Exists(@"..\Queryconfig.xml")? @"..\Queryconfig.xml":
                                        (File.Exists(@"..\..\Queryconfig.xml") ? @"..\..\Queryconfig.xml" :null));

            if (String.IsNullOrEmpty(QueryFileLocation))
                throw new QueryRegExNotFoundException();


            xml.Load(QueryFileLocation);
            XmlNodeList QueryRegEx = xml.GetElementsByTagName("QueryRegEx");
            foreach (XmlElement node in QueryRegEx)
            {
                _listQueryConfig.Add(new QueryConfiguration(node));
            }

            //also update the self element queryConfiguration
            this.queryConfiguration = _listQueryConfig;
            return _listQueryConfig;
        }
        public List<QueryConfiguration> GetQueryConfiguration()
        {
            if(this.queryConfiguration==null || this.queryConfiguration.Count==0)
            {
                this.GetQueryRegEx();
            }
            XmlDocument xml = new XmlDocument();
            string QueryFileLocation = File.Exists("Queryconfig.xml") ? "Queryconfig.xml" :
                                        (File.Exists(@"..\Queryconfig.xml") ? @"..\Queryconfig.xml" :
                                        (File.Exists(@"..\..\Queryconfig.xml") ? @"..\..\Queryconfig.xml" : null));

            if (String.IsNullOrEmpty(QueryFileLocation))
                throw new QueryConfigurationNotFoundException();


            xml.Load(QueryFileLocation);
            XmlNodeList QueryAditionalConfiguration = xml.GetElementsByTagName("Qpart");
            foreach (QueryConfiguration query in this.queryConfiguration)
            {
                var relativeNode= QueryAditionalConfiguration.Cast<XmlElement>()
                                   .Where(n => n.Attributes["Name"].Value.ToUpper() == query.Name.ToUpper())
                                   .FirstOrDefault();
                query.GetAditionalConfiguration(relativeNode);
            }
            return queryConfiguration;
        }
    }
}
