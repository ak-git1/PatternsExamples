using System;

namespace PatternsExamples.Behavioral.TemplateMethod
{
    abstract class Education
    {
        public void Learn()
        {
            Enter();
            Study();
            PassExams();
            GetDocument();
        }

        public abstract void Enter();

        public abstract void Study();

        public virtual void PassExams()
        {
            Console.WriteLine("Сдаем выпускные экзамены");
        }

        public abstract void GetDocument();
    }

    class School : Education
    {
        public override void Enter()
        {
            Console.WriteLine("Идем в первый класс");
        }

        public override void Study()
        {
            Console.WriteLine("Посещаем уроки, делаем домашние задания");
        }

        public override void GetDocument()
        {
            Console.WriteLine("Получаем аттестат о среднем образовании");
        }
    }

    class University : Education
    {
        public override void Enter()
        {
            Console.WriteLine("Сдаем вступительные экзамены и поступаем в ВУЗ");
        }

        public override void Study()
        {
            Console.WriteLine("Посещаем лекции");
            Console.WriteLine("Проходим практику");
        }

        public override void PassExams()
        {
            Console.WriteLine("Сдаем экзамен по специальности");
        }

        public override void GetDocument()
        {
            Console.WriteLine("Получаем диплом о высшем образовании");
        }
    }

    class Usage
    {
        public void Run()
        {
            School school = new School();
            University university = new University();

            school.Learn();
            university.Learn();

            Console.Read();
        }
    }
}
