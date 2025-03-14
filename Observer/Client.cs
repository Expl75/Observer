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

            Monitor.Subscribe(reporter);

            new ExternalClass().DoWork(reporter);

            var i = 0;
            while (i < 5)
            {
                Monitor.GetTemperature();

                i++;
            }
        }
    }

    public class ExternalClass
    {
        public TemperatureMonitor NewMonitor = new TemperatureMonitor();

        public void DoWork(TemperatureReporter reporter)
        {
            //do work...
            reporter.Unsubscribe();
            reporter.Subscribe(NewMonitor);
        }
    }
}
