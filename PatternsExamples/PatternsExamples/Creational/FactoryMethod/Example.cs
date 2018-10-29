using System;

namespace PatternsExamples.Creational.FactoryMethod
{
    abstract class Developer
    {
        public string Name { get; set; }

        protected Developer(string n)
        {
            Name = n;
        }

        public abstract House Create();
    }

    class PanelDeveloper : Developer
    {
        public PanelDeveloper(string n) : base(n)
        {
        }

        public override House Create()
        {
            return new PanelHouse();
        }
    }

    class WoodDeveloper : Developer
    {
        public WoodDeveloper(string n) : base(n)
        {
        }

        public override House Create()
        {
            return new WoodHouse();
        }
    }

    abstract class House
    {
    }

    class PanelHouse : House
    {
        public PanelHouse()
        {
            Console.WriteLine("Панельный дом построен");
        }
    }

    class WoodHouse : House
    {
        public WoodHouse()
        {
            Console.WriteLine("Деревянный дом построен");
        }
    }

    class Usage
    {
        public void Run()
        {
            Developer dev = new PanelDeveloper("ООО КирпичСтрой");
            House house1 = dev.Create();

            dev = new WoodDeveloper("Частный застройщик");
            House house2 = dev.Create();

            Console.ReadLine();
        }
    }
}
