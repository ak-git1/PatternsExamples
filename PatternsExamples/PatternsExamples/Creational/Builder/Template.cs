using System.Collections.Generic;

namespace PatternsExamples.Creational.Builder
{
    class Client
    {
        void Main()
        {
            Builder builder = new ConcreteBuilder();
            Director director = new Director(builder);
            director.Construct();
            Product product = builder.GetResult();
        }
    }

    class Director
    {
        Builder _builder;

        public Director(Builder builder)
        {
            _builder = builder;
        }

        public void Construct()
        {
            _builder.BuildPartA();
            _builder.BuildPartB();
            _builder.BuildPartC();
        }
    }

    abstract class Builder
    {
        public abstract void BuildPartA();

        public abstract void BuildPartB();

        public abstract void BuildPartC();

        public abstract Product GetResult();
    }

    class Product
    {
        List<object> _parts = new List<object>();

        public void Add(string part)
        {
            _parts.Add(part);
        }
    }

    class ConcreteBuilder : Builder
    {
        Product _product = new Product();

        public override void BuildPartA()
        {
            _product.Add("Part A");
        }

        public override void BuildPartB()
        {
            _product.Add("Part B");
        }

        public override void BuildPartC()
        {
            _product.Add("Part C");
        }

        public override Product GetResult()
        {
            return _product;
        }
    }
}
