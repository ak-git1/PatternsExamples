using System;

namespace PatternsExamples.Structural.Adapter
{
    interface ITransport
    {
        void Drive();
    }

    class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Машина едет по дороге");
        }
    }

    class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }

    interface IAnimal
    {
        void Move();
    }

    class Camel : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Верблюд идет по пескам пустыни");
        }
    }

    class CamelToTransportAdapter : ITransport
    {
        Camel _camel;
        public CamelToTransportAdapter(Camel c)
        {
            _camel = c;
        }

        public void Drive()
        {
            _camel.Move();
        }
    }

    class Usage
    {
        public void Run()
        {
            Driver driver = new Driver();
            Auto auto = new Auto();

            driver.Travel(auto);

            Camel camel = new Camel();

            ITransport camelTransport = new CamelToTransportAdapter(camel);
            driver.Travel(camelTransport);

            Console.Read();
        }
    }
}
