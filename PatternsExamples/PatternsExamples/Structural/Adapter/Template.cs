namespace PatternsExamples.Structural.Adapter
{
    class Client
    {
        public void Request(Target target)
        {
            target.Request();
        }
    }

    class Target
    {
        public virtual void Request()
        {
        }
    }


    class Adapter : Target
    {
        private Adaptee _adaptee = new Adaptee();

        public override void Request()
        {
            _adaptee.SpecificRequest();
        }
    }

    class Adaptee
    {
        public void SpecificRequest()
        {
        }
    }
}
