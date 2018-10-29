using System;

namespace PatternsExamples.Creational.Prototype
{
    interface IFigure
    {
        IFigure Clone();

        void GetInfo();
    }

    class Rectangle : IFigure
    {
        int _width;
        int _height;

        public Rectangle(int w, int h)
        {
            _width = w;
            _height = h;
        }

        public IFigure Clone()
        {
            return MemberwiseClone() as IFigure;
        }

        public void GetInfo()
        {
            Console.WriteLine("Прямоугольник длиной {0} и шириной {1}", _height, _width);
        }
    }

    class Circle : IFigure
    {
        int _radius;

        public Circle(int r)
        {
            _radius = r;
        }

        public IFigure Clone()
        {
            return MemberwiseClone() as IFigure;
        }

        public void GetInfo()
        {
            Console.WriteLine("Круг радиусом {0}", _radius);
        }
    }

    class Usage
    {
        public void Run()
        {
            IFigure figure = new Rectangle(30, 40);
            IFigure clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            figure = new Circle(30);
            clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            Console.Read();
        }
    }
}
