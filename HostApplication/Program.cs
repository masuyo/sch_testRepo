using NHLService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HostApplication
{
    class Program
    {
        //commitcomm
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(NHLStatService)))
            {
                host.Open();
                Console.WriteLine("RUNNING: {0}", host.BaseAddresses[0].AbsoluteUri);
                Console.ReadLine();
            }
        }
    }
}
