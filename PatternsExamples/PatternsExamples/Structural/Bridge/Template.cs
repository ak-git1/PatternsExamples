namespace PatternsExamples.Structural.Bridge
{
    class Client
    {
        void Main()
        {
            Abstraction abstraction;
            abstraction = new RefinedAbstraction(new ConcreteImplementorA());
            abstraction.Operation();
            abstraction.Implementor = new ConcreteImplementorB();
            abstraction.Operation();
        }
    }

    abstract class Abstraction
    {
        protected Implementor implementor;

        public Implementor Implementor
        {
            set => implementor = value;
        }

        public Abstraction(Implementor imp)
        {
            implementor = imp;
        }

        public virtual void Operation()
        {
            implementor.OperationImp();
        }
    }

    abstract class Implementor
    {
        public abstract void OperationImp();
    }

    class RefinedAbstraction : Abstraction
    {
        public RefinedAbstraction(Implementor imp)
            : base(imp)
        {            
        }
        public override void Operation()
        {
        }
    }

    class ConcreteImplementorA : Implementor
    {
        public override void OperationImp()
        {
        }
    }

    class ConcreteImplementorB : Implementor
    {
        public override void OperationImp()
        {
        }
    }
}
