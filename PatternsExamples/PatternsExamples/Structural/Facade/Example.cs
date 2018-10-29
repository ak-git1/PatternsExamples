using System;

namespace PatternsExamples.Structural.Facade
{
    class TextEditor
    {
        public void CreateCode()
        {
            Console.WriteLine("Написание кода");
        }

        public void Save()
        {
            Console.WriteLine("Сохранение кода");
        }
    }

    class Compiller
    {
        public void Compile()
        {
            Console.WriteLine("Компиляция приложения");
        }
    }

    class Clr
    {
        public void Execute()
        {
            Console.WriteLine("Выполнение приложения");
        }
        public void Finish()
        {
            Console.WriteLine("Завершение работы приложения");
        }
    }

    class VisualStudioFacade
    {
        TextEditor _textEditor;
        Compiller _compiller;
        Clr _clr;

        public VisualStudioFacade(TextEditor te, Compiller compil, Clr clr)
        {
            _textEditor = te;
            _compiller = compil;
            _clr = clr;
        }

        public void Start()
        {
            _textEditor.CreateCode();
            _textEditor.Save();
            _compiller.Compile();
            _clr.Execute();
        }

        public void Stop()
        {
            _clr.Finish();
        }
    }

    class Programmer
    {
        public void CreateApplication(VisualStudioFacade facade)
        {
            facade.Start();
            facade.Stop();
        }
    }

    class Usage
    {
        public void Run()
        {
            TextEditor textEditor = new TextEditor();
            Compiller compiller = new Compiller();
            Clr clr = new Clr();

            VisualStudioFacade ide = new VisualStudioFacade(textEditor, compiller, clr);

            Programmer programmer = new Programmer();
            programmer.CreateApplication(ide);

            Console.Read();
        }
    }
}
