using System;
using System.Collections.Generic;

namespace PatternsExamples.Behavioral.Observer.Example
{
    interface IObserver
    {
        void Update(Object ob);
    }

    interface IObservable
    {
        void RegisterObserver(IObserver o);

        void RemoveObserver(IObserver o);

        void NotifyObservers();
    }

    class Stock : IObservable
    {
        StockInfo stockInfo;

        List<IObserver> _observers;
        public Stock()
        {
            _observers = new List<IObserver>();
            stockInfo = new StockInfo();
        }

        public void RegisterObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            _observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in _observers)
            {
                o.Update(stockInfo);
            }
        }

        public void Market()
        {
            Random rnd = new Random();
            stockInfo.Usd = rnd.Next(20, 40);
            stockInfo.Euro = rnd.Next(30, 50);
            NotifyObservers();
        }
    }

    class StockInfo
    {
        public int Usd { get; set; }

        public int Euro { get; set; }
    }

    class Broker : IObserver
    {
        public string Name { get; set; }

        IObservable stock;

        public Broker(string name, IObservable obs)
        {
            this.Name = name;
            stock = obs;
            stock.RegisterObserver(this);
        }

        public void Update(object ob)
        {
            StockInfo sInfo = (StockInfo)ob;

            if (sInfo.Usd > 30)
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, sInfo.Usd);
            else
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, sInfo.Usd);
        }

        public void StopTrade()
        {
            stock.RemoveObserver(this);
            stock = null;
        }
    }

    class Bank : IObserver
    {
        public string Name { get; set; }

        IObservable stock;

        public Bank(string name, IObservable obs)
        {
            this.Name = name;
            stock = obs;
            stock.RegisterObserver(this);
        }

        public void Update(object ob)
        {
            StockInfo stockInfo = (StockInfo)ob;

            if (stockInfo.Euro > 40)
                Console.WriteLine("Банк {0} продает евро;  Курс евро: {1}", this.Name, stockInfo.Euro);
            else
                Console.WriteLine("Банк {0} покупает евро;  Курс евро: {1}", this.Name, stockInfo.Euro);
        }
    }
}
