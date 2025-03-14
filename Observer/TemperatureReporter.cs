using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class TemperatureReporter : IObserver<Temperature>
    {
        private IDisposable unsubscriber;

        public virtual void Subscribe(IObservable<Temperature> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public virtual void OnNext(Temperature value)
        {
            Console.WriteLine("The temperature is {0}°C at {1:g}", value.Degrees, value.Date);
        }






        public virtual void OnCompleted()
        {
        }

        public virtual void OnError(Exception error)
        {
            // Do nothing.
        }
    }
}
