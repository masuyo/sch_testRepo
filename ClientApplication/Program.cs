using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientApplication.NHLServiceReference1;

namespace ClientApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please press enter..");
            Console.ReadLine();

            NHLStatServiceClient client = new NHLStatServiceClient();
            foreach (var akt in client.GetAllResults())
            {
                Console.WriteLine("{0}: {1} wins", akt.TeamName, akt.NumberOfWins);
            }


            foreach (var akt in client.GetAllMatches())
            {
                Console.WriteLine("{0} : {1} \t\t\t {2} : {3}", akt.Team1, akt.Team2,akt.Goal1,akt.Goal2);
            }
            Console.ReadLine();

        }
    }
}
