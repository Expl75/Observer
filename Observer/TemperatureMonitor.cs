using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class TemperatureMonitor : IObservable<Temperature>
    {
        List<IObserver<Temperature>> observers;

        public TemperatureMonitor()
        {
            observers = new List<IObserver<Temperature>>();
        }

        public IDisposable Subscribe(IObserver<Temperature> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);

            return new Unsubscriber(observers, observer);
        }
        
        public void Notify(Temperature temperature)
        {
            foreach (var observer in observers)
                observer.OnNext(temperature);
        }

        //business logic
        public void GetTemperature()
        {
            try
            {
                var temp = new Temperature(new Random().Next(-20, 20), DateTime.Now);

                Thread.Sleep(1000);

                Notify(temp);
            }
            catch (Exception ex)
            {
                foreach(var observer in observers)
                    observer.OnError(ex);
            }
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Temperature>> _observers;
            private IObserver<Temperature> _observer;

            public Unsubscriber(List<IObserver<Temperature>> observers, IObserver<Temperature> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null) 
                    _observers.Remove(_observer);
            }
        }
    }
}
