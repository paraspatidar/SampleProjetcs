using GalaxyLibrary.DataMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyLibrary
{
    public sealed class  LoggerHelper
    {
        
        private static readonly Lazy<LoggerHelper> lazy =
         new Lazy<LoggerHelper>(() => new LoggerHelper());

        public static LoggerHelper Instance { get { return lazy.Value; } }

        private LoggerHelper()
        {

        }

        public void LogConsole(string mesg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(mesg);
        }

        public void LogConsole(string mesg, string messagetype)
        {
            if(messagetype==Constants.MessageType.WARNING)
                   Console.ForegroundColor = ConsoleColor.Yellow;
            if (messagetype == Constants.MessageType.FAILURE)
                Console.ForegroundColor = ConsoleColor.DarkRed;
            if (messagetype == Constants.MessageType.SUCCESS)
                Console.ForegroundColor = ConsoleColor.Green;
            if (messagetype == Constants.MessageType.INFO)
                Console.ForegroundColor = ConsoleColor.Blue;


            Console.WriteLine(mesg);
        }
        public void LogConsole(string mesg, string messagetype, bool newLine=true)
        {
            if (messagetype == Constants.MessageType.WARNING)
                Console.ForegroundColor = ConsoleColor.Yellow;
            if (messagetype == Constants.MessageType.FAILURE)
                Console.ForegroundColor = ConsoleColor.DarkRed;
            if (messagetype == Constants.MessageType.SUCCESS)
                Console.ForegroundColor = ConsoleColor.Green;
            if (messagetype == Constants.MessageType.INFO)
                Console.ForegroundColor = ConsoleColor.Blue;

            if (newLine)
                Console.WriteLine(mesg);
            else
                Console.Write(mesg);
        }

        public void LogMapping(IDataMappingHolder _dataMappingHolder)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Environment.NewLine);
            sb.AppendLine("***********************************************************************");
            sb.AppendLine("MAPPING FOR ROMAN CONSTANTS :");
            sb.AppendLine("-----------------------------------------------------------------------");
            sb.AppendLine("KEY      ROMAN       DECIMAL");
            sb.AppendLine("----     ------      --------");
                        
            foreach (var element in _dataMappingHolder.RomanConstantsTable)
            {
                sb.AppendLine(element.Key + "\t  " + element.Value.RomanChar + "\t\t" + element.Value.DecimalValue);
            }

            sb.AppendLine("-----------------------------------------------------------------------");

            sb.AppendLine("MAPPING FOR CALCULATIVE METALS :");
            sb.AppendLine("-----------------------------------------------------------------------");
            sb.AppendLine("METAL            CREDITS");
            sb.AppendLine("----             ------");

            foreach (var element in _dataMappingHolder.DeclarativeCalculationTable)
            {
                sb.AppendLine(element.Key + "\t\t" + element.Value );
            }

            sb.AppendLine("-----------------------------------------------------------------------");


            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(sb.ToString());
        }
    }
}
