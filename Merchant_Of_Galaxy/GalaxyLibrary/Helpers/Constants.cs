using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GalaxyLibrary
{
    public static class Constants
    {

        public sealed class Querytype
        {
            private Querytype()
            {

            }
            public const string DECLARATIONQUERY = "DECLARATIONQUERY";
            public const string CREDITQUERY = "CREDITQUERY";
            public const string QUNATITIVEQUERY = "QUNATITIVEQUERY";
            public const string CALCULATIVEDECLARATIVEQUERY = "CALCULATIVEDECLARATIVEQUERY";
        }

        public sealed class MessageType
        {
            private MessageType()
            {

            }
            public const string INFO = "INFO";
            public const string WARNING = "WARNING";
            public const string FAILURE = "FAILURE";
            public const string SUCCESS = "SUCCESS";

            
        }
    }
}
