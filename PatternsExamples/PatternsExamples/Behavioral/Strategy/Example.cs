using System;

namespace PatternsExamples.Behavioral.Strategy
{
    interface IMovable
    {
        void Move();
    }

    class PetrolMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на бензине");
        }
    }

    class ElectricMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на электричестве");
        }
    }

    class Car
    {
        protected int Passengers; // кол-во пассажиров
        protected string Model; // модель автомобиля

        public Car(int num, string model, IMovable mov)
        {
            Passengers = num;
            Model = model;
            Movable = mov;
        }

        public IMovable Movable { private get; set; }

        public void Move()
        {
            Movable.Move();
        }
    }

    class Usage
    {
        public void Run()
        {
            Car auto = new Car(4, "Volvo", new PetrolMove());
            auto.Move();
            auto.Movable = new ElectricMove();
            auto.Move();

            Console.ReadLine();
        }
    }
}
