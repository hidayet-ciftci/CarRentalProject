using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CCS.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Console Loglandi");
        }
    }
}
