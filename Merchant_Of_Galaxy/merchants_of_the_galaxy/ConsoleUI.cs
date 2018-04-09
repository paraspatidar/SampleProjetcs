using GalaxyLibrary;
using GalaxyLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace merchants_of_the_galaxy
{
    
    class ConsoleUI
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome ,Please Speak the Alian Language . To Exit at any point , please type EXIT"+Environment.NewLine);
            Console.Write("For Instructions & Sample Queries , Visit : http://bit.ly/ParasGitHub " + Environment.NewLine);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("WAITING FOR  INPUT !!!!");
            Console.WriteLine("___________________________________________________");
            QueryProcessor queryProcessor = new QueryProcessor();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                var query = Console.ReadLine();

                if (query == "EXIT")
                    break;


                var result = queryProcessor.ProcessQuery(query);

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(result);
                Console.WriteLine(Environment.NewLine);
                Console.WriteLine("WAITING FOR NEXT INPUT !!!!");
                Console.WriteLine("___________________________________________________");
                Console.WriteLine(Environment.NewLine);
            }

        }
    }
}
