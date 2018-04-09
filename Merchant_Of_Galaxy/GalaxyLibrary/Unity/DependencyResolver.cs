using GalaxyLibrary.DataMapping;
using LanguageProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace GalaxyLibrary.Unity
{
   public class DependencyResolver : UnityContainer
    {
        
        public static IUnityContainer DependencyRegiration()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IDataMappingHolder, DataMappingHolder>();
            return container;
        }

    }
}
