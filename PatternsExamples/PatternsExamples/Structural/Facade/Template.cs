namespace PatternsExamples.Structural.Facade
{
    public class SubsystemA
    {
        public void A1()
        {            
        }
    }

    public class SubsystemB
    {
        public void B1()
        {            
        }
    }

    public class SubsystemC
    {
        public void C1()
        {            
        }
    }

    public class Facade
    {
        SubsystemA _subsystemA;
        SubsystemB _subsystemB;
        SubsystemC _subsystemC;

        public Facade(SubsystemA sa, SubsystemB sb, SubsystemC sc)
        {
            _subsystemA = sa;
            _subsystemB = sb;
            _subsystemC = sc;
        }

        public void Operation1()
        {
            _subsystemA.A1();
            _subsystemB.B1();
            _subsystemC.C1();
        }

        public void Operation2()
        {
            _subsystemB.B1();
            _subsystemC.C1();
        }
    }

    class Client
    {
        public void Main()
        {
            Facade facade = new Facade(new SubsystemA(), new SubsystemB(), new SubsystemC());
            facade.Operation1();
            facade.Operation2();
        }
    }
}
