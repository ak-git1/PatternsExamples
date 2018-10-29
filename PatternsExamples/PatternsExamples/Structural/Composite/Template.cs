using System;
using System.Collections.Generic;

namespace PatternsExamples.Structural.Composite
{
    class Client
    {
        public void Main()
        {
            Component root = new Composite("Root");
            Component leaf = new Leaf("Leaf");
            Composite subtree = new Composite("Subtree");
            root.Add(leaf);
            root.Add(subtree);
            root.Display();
        }
    }

    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Display();

        public abstract void Add(Component c);

        public abstract void Remove(Component c);
    }

    class Composite : Component
    {
        List<Component> _children = new List<Component>();

        public Composite(string name)
            : base(name)
        {            
        }

        public override void Add(Component component)
        {
            _children.Add(component);
        }

        public override void Remove(Component component)
        {
            _children.Remove(component);
        }

        public override void Display()
        {
            Console.WriteLine(name);

            foreach (Component component in _children)
            {
                component.Display();
            }
        }
    }
    class Leaf : Component
    {
        public Leaf(string name)
            : base(name)
        {            
        }

        public override void Display()
        {
            Console.WriteLine(name);
        }

        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }
    }
}
