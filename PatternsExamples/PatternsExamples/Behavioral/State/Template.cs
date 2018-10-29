using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsExamples.Behavioral.State
{
    abstract class State
    {
        public abstract void Handle(Context context);
    }

    class StateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new StateB();
        }
    }

    class StateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new StateA();
        }
    }

    class Context
    {
        public State State { get; set; }

        public Context(State state)
        {
            State = state;
        }

        public void Request()
        {
            State.Handle(this);
        }
    }
}
