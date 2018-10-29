namespace PatternsExamples.Behavioral.Strategy
{
    public interface IStrategy
    {
        void Algorithm();
    }

    public class ConcreteStrategy1 : IStrategy
    {
        public void Algorithm()
        {            
        }
    }

    public class ConcreteStrategy2 : IStrategy
    {
        public void Algorithm()
        {            
        }
    }

    public class Context
    {
        public IStrategy ContextStrategy { get; set; }

        public Context(IStrategy strategy)
        {
            ContextStrategy = strategy;
        }

        public void ExecuteAlgorithm()
        {
            ContextStrategy.Algorithm();
        }
    }
}
