using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsExamples.Behavioral.TemplateMethod
{
    abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            Operation1();
            Operation2();
        }

        public abstract void Operation1();

        public abstract void Operation2();
    }

    class ConcreteClass : AbstractClass
    {
        public override void Operation1()
        {
        }

        public override void Operation2()
        {
        }
    }
}
