using System;
using System.Collections.Generic;

namespace PatternsExamples.Structural.Composite.Example
{
    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public virtual void Add(Component component) { }

        public virtual void Remove(Component component) { }

        public virtual void Print()
        {
            Console.WriteLine(name);
        }
    }

    class Directory : Component
    {
        private List<Component> _components = new List<Component>();

        public Directory(string name)
            : base(name)
        {
        }

        public override void Add(Component component)
        {
            _components.Add(component);
        }

        public override void Remove(Component component)
        {
            _components.Remove(component);
        }

        public override void Print()
        {
            Console.WriteLine("Узел " + name);
            Console.WriteLine("Подузлы:");
            for (int i = 0; i < _components.Count; i++)
            {
                _components[i].Print();
            }
        }
    }

    class File : Component
    {
        public File(string name)
            : base(name)
        { }
    }

    class Usage
    {
        public void Run()
        {
            Component fileSystem = new Directory("Файловая система");

            Component diskC = new Directory("Диск С");
            Component pngFile = new File("12345.png");
            Component docxFile = new File("Document.docx");

            diskC.Add(pngFile);
            diskC.Add(docxFile);

            fileSystem.Add(diskC);
            fileSystem.Print();
            Console.WriteLine();

            diskC.Remove(pngFile);

            Component docsFolder = new Directory("Мои Документы");
            Component txtFile = new File("readme.txt");
            Component csFile = new File("Program.cs");

            docsFolder.Add(txtFile);
            docsFolder.Add(csFile);
            diskC.Add(docsFolder);

            fileSystem.Print();

            Console.Read();
        }
    }
}
