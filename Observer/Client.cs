using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    internal class Client
    {
        public TemperatureMonitor Monitor = new TemperatureMonitor();
        public void ClientCode()
        {
            var reporter = new TemperatureReporter();

            reporter.Subscribe(Monitor);

            var i = 0;
            while (i < 5)
            {
                Monitor.GetTemperature();

                i++;
            }
        }
    }
}
