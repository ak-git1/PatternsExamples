using System.Collections;

namespace PatternsExamples.Structural.Flyweight
{
    class FlyweightFactory
    {
        Hashtable _flyweights = new Hashtable();

        public FlyweightFactory()
        {
            _flyweights.Add("X", new ConcreteFlyweight());
            _flyweights.Add("Y", new ConcreteFlyweight());
            _flyweights.Add("Z", new ConcreteFlyweight());
        }

        public Flyweight GetFlyweight(string key)
        {
            if (!_flyweights.ContainsKey(key))
                _flyweights.Add(key, new ConcreteFlyweight());
            return _flyweights[key] as Flyweight;
        }
    }

    abstract class Flyweight
    {
        public abstract void Operation(int extrinsicState);
    }

    class ConcreteFlyweight : Flyweight
    {
        int _intrinsicState;

        public override void Operation(int extrinsicState)
        {
        }
    }

    class UnsharedConcreteFlyweight : Flyweight
    {
        int _allState;

        public override void Operation(int extrinsicState)
        {
            _allState = extrinsicState;
        }
    }

    class Client
    {
        void Main()
        {
            int extrinsicstate = 22;

            FlyweightFactory f = new FlyweightFactory();

            Flyweight fx = f.GetFlyweight("X");
            fx.Operation(--extrinsicstate);

            Flyweight fy = f.GetFlyweight("Y");
            fy.Operation(--extrinsicstate);

            Flyweight fd = f.GetFlyweight("D");
            fd.Operation(--extrinsicstate);

            UnsharedConcreteFlyweight uf = new UnsharedConcreteFlyweight();

            uf.Operation(--extrinsicstate);
        }
    }
}
