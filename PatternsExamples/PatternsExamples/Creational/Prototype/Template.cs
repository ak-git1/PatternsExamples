using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsExamples.Creational.Prototype
{
    class Client
    {
        void Operation()
        {
            Prototype prototype = new ConcretePrototype1(1);
            Prototype clone = prototype.Clone();
            prototype = new ConcretePrototype2(2);
            clone = prototype.Clone();
        }
    }

    abstract class Prototype
    {
        public int Id { get; }

        public Prototype(int id)
        {
            this.Id = id;
        }

        public abstract Prototype Clone();
    }

    class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(int id) : base(id)
        {            
        }

        public override Prototype Clone()
        {
            return new ConcretePrototype1(Id);
        }
    }

    class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2(int id) : base(id)
        {            
        }

        public override Prototype Clone()
        {
            return new ConcretePrototype2(Id);
        }
    }
}
