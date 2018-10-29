namespace PatternsExamples.Behavioral.Mediator
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
    }

    class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(Mediator mediator)
            : base(mediator)
        {            
        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        { }
    }

    class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(Mediator mediator)
            : base(mediator)
        {            
        }

        public void Send(string message)
        {
            mediator.Send(message, this);
        }

        public void Notify(string message)
        {            
        }
    }

    class ConcreteMediator : Mediator
    {
        public ConcreteColleague1 Colleague1 { get; set; }

        public ConcreteColleague2 Colleague2 { get; set; }

        public override void Send(string msg, Colleague colleague)
        {
            if (Colleague1 == colleague)
                Colleague2.Notify(msg);
            else
                Colleague1.Notify(msg);
        }
    }
}
