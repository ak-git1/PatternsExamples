using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsExamples.Behavioral.Command
{
    abstract class Command
    {
        public abstract void Execute();
        public abstract void Undo();
    }


    class ConcreteCommand : Command
    {
        Receiver _receiver;

        public ConcreteCommand(Receiver r)
        {
            _receiver = r;
        }

        public override void Execute()
        {
            _receiver.Operation();
        }

        public override void Undo()
        {            
        }
    }

    class Receiver
    {
        public void Operation()
        {            
        }
    }

    class Invoker
    {
        Command _command;

        public void SetCommand(Command c)
        {
            _command = c;
        }

        public void Run()
        {
            _command.Execute();
        }

        public void Cancel()
        {
            _command.Undo();
        }
    }

    class Client
    {
        void Main()
        {
            Invoker invoker = new Invoker();
            Receiver receiver = new Receiver();
            ConcreteCommand command = new ConcreteCommand(receiver);
            invoker.SetCommand(command);
            invoker.Run();
        }
    }
}
