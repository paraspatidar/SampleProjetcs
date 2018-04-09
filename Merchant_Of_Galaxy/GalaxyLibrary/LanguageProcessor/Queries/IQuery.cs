using GalaxyLibrary;
using GalaxyLibrary.DataMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageProcessor
{
    public interface IQuery
    {
        string ProcessQuery(IDataMappingHolder _dataMappingHolder);
        
    }
}
