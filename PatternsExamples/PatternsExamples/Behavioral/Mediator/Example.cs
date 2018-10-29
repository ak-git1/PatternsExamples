using System;

namespace PatternsExamples.Behavioral.Mediator.Example
{
    abstract class Mediator
    {
        public abstract void Send(string msg, Colleague colleague);
    }

    abstract class Colleague
    {
        protected Mediator mediator;

        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public virtual void Send(string message)
        {
            mediator.Send(message, this);
        }

        public abstract void Notify(string message);
    }

    class CustomerColleague : Colleague
    {
        public CustomerColleague(Mediator mediator) : base(mediator)
        {            
        }

        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение заказчику: " + message);
        }
    }

    class ProgrammerColleague : Colleague
    {
        public ProgrammerColleague(Mediator mediator) : base(mediator)
        {            
        }

        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение программисту: " + message);
        }
    }

    class TesterColleague : Colleague
    {
        public TesterColleague(Mediator mediator) : base(mediator)
        {            
        }

        public override void Notify(string message)
        {
            Console.WriteLine("Сообщение тестеру: " + message);
        }
    }

    class ManagerMediator : Mediator
    {
        public Colleague Customer { get; set; }

        public Colleague Programmer { get; set; }

        public Colleague Tester { get; set; }

        public override void Send(string msg, Colleague colleague)
        {
            if (Customer == colleague)
                Programmer.Notify(msg);
            else if (Programmer == colleague)
                Tester.Notify(msg);
            else if (Tester == colleague)
                Customer.Notify(msg);
        }
    }

    class Usage
    {
        public void Run()
        {
            ManagerMediator mediator = new ManagerMediator();
            Colleague customer = new CustomerColleague(mediator);
            Colleague programmer = new ProgrammerColleague(mediator);
            Colleague tester = new TesterColleague(mediator);
            mediator.Customer = customer;
            mediator.Programmer = programmer;
            mediator.Tester = tester;
            customer.Send("Есть заказ, надо сделать программу");
            programmer.Send("Программа готова, надо протестировать");
            tester.Send("Программа протестирована и готова к продаже");

            Console.Read();
        }
    }
}
