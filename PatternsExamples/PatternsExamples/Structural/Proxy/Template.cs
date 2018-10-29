namespace PatternsExamples.Structural.Proxy
{
    class Client
    {
        void Main()
        {
            Subject subject = new Proxy();
            subject.Request();
        }
    }

    abstract class Subject
    {
        public abstract void Request();
    }

    class RealSubject : Subject
    {
        public override void Request()
        {            
        }
    }

    class Proxy : Subject
    {
        RealSubject _realSubject;

        public override void Request()
        {
            if (_realSubject == null)
                _realSubject = new RealSubject();
            _realSubject.Request();
        }
    }
}
