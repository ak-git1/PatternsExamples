using System;
using System.Collections.Generic;

namespace PatternsExamples.Structural.Flyweight
{
    abstract class House
    {
        protected int stages;

        public abstract void Build(double longitude, double latitude);
    }

    class PanelHouse : House
    {
        public PanelHouse()
        {
            stages = 16;
        }

        public override void Build(double longitude, double latitude)
        {
            Console.WriteLine("Построен панельный дом из 16 этажей; координаты: {0} широты и {1} долготы",
                latitude, longitude);
        }
    }

    class BrickHouse : House
    {
        public BrickHouse()
        {
            stages = 5;
        }

        public override void Build(double longitude, double latitude)
        {
            Console.WriteLine("Построен кирпичный дом из 5 этажей; координаты: {0} широты и {1} долготы",
                latitude, longitude);
        }
    }

    class HouseFactory
    {
        Dictionary<string, House> _houses = new Dictionary<string, House>();

        public HouseFactory()
        {
            _houses.Add("Panel", new PanelHouse());
            _houses.Add("Brick", new BrickHouse());
        }

        public House GetHouse(string key)
        {
            if (_houses.ContainsKey(key))
                return _houses[key];
            else
                return null;
        }
    }

    class Usage
    {
        public void Run()
        {
            double longitude = 37.61;
            double latitude = 55.74;

            HouseFactory houseFactory = new HouseFactory();
            for (int i = 0; i < 5; i++)
            {
                House panelHouse = houseFactory.GetHouse("Panel");
                panelHouse?.Build(longitude, latitude);
                longitude += 0.1;
                latitude += 0.1;
            }

            for (int i = 0; i < 5; i++)
            {
                House brickHouse = houseFactory.GetHouse("Brick");
                brickHouse?.Build(longitude, latitude);
                longitude += 0.1;
                latitude += 0.1;
            }

            Console.Read();
        }
    }
}
