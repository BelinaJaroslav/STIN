﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace STINServer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WCFService)))
            {
                host.Open();
                Console.WriteLine("server is open");
                Console.WriteLine("Press enter to quit");
                Console.ReadLine();
            }
        }
    }
}
