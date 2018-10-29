using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsExamples.Behavioral.Command
{
    interface ICommand
    {
        void Execute();
        void Undo();
    }

    class Tv
    {
        public void On()
        {
            Console.WriteLine("Телевизор включен!");
        }

        public void Off()
        {
            Console.WriteLine("Телевизор выключен...");
        }
    }

    class TVOnCommand : ICommand
    {
        Tv _tv;

        public TVOnCommand(Tv tvSet)
        {
            _tv = tvSet;
        }

        public void Execute()
        {
            _tv.On();
        }

        public void Undo()
        {
            _tv.Off();
        }
    }

    class Pult
    {
        ICommand _command;

        public Pult() { }

        public void SetCommand(ICommand com)
        {
            _command = com;
        }

        public void PressButton()
        {
            _command.Execute();
        }
        public void PressUndo()
        {
            _command.Undo();
        }
    }

    class Usage
    {
        public void Run()
        {
            Pult pult = new Pult();
            Tv tv = new Tv();
            pult.SetCommand(new TVOnCommand(tv));
            pult.PressButton();
            pult.PressUndo();

            Console.Read();
        }
    }
}
