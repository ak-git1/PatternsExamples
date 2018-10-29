using System.Collections.Generic;

namespace PatternsExamples.Behavioral.Observer
{
    interface IObservable
    {
        void AddObserver(IObserver o);

        void RemoveObserver(IObserver o);

        void NotifyObservers();
    }

    class ConcreteObservable : IObservable
    {
        private List<IObserver> _observers;

        public ConcreteObservable()
        {
            _observers = new List<IObserver>();
        }

        public void AddObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            _observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in _observers)
                observer.Update();
        }
    }

    interface IObserver
    {
        void Update();
    }

    class ConcreteObserver : IObserver
    {
        public void Update()
        {
        }
    }
}
