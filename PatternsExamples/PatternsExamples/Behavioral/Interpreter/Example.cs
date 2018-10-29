using System;
using System.Collections.Generic;

namespace PatternsExamples.Behavioral.Interpreter.Example
{
    class Context
    {
        Dictionary<string, int> _variables;

        public Context()
        {
            _variables = new Dictionary<string, int>();
        }

        public int GetVariable(string name)
        {
            return _variables[name];
        }

        public void SetVariable(string name, int value)
        {
            if (_variables.ContainsKey(name))
                _variables[name] = value;
            else
                _variables.Add(name, value);
        }
    }
    
    interface IExpression
    {
        int Interpret(Context context);
    }

    class NumberExpression : IExpression
    {
        string _name;

        public NumberExpression(string variableName)
        {
            _name = variableName;
        }

        public int Interpret(Context context)
        {
            return context.GetVariable(_name);
        }
    }

    class AddExpression : IExpression
    {
        IExpression _leftExpression;
        IExpression _rightExpression;

        public AddExpression(IExpression left, IExpression right)
        {
            _leftExpression = left;
            _rightExpression = right;
        }

        public int Interpret(Context context)
        {
            return _leftExpression.Interpret(context) + _rightExpression.Interpret(context);
        }
    }

    class SubtractExpression : IExpression
    {
        IExpression _leftExpression;
        IExpression _rightExpression;

        public SubtractExpression(IExpression left, IExpression right)
        {
            _leftExpression = left;
            _rightExpression = right;
        }

        public int Interpret(Context context)
        {
            return _leftExpression.Interpret(context) - _rightExpression.Interpret(context);
        }
    }

    class Usage
    {
        public void Run()
        {
            Context context = new Context();

            int x = 5;
            int y = 8;
            int z = 2;


            context.SetVariable("x", x);
            context.SetVariable("y", y);
            context.SetVariable("z", z);

            IExpression expression = new SubtractExpression(
                new AddExpression(
                    new NumberExpression("x"), new NumberExpression("y")
                ),
                new NumberExpression("z")
            );

            int result = expression.Interpret(context);
            Console.WriteLine("результат: {0}", result);

            Console.Read();
        }
    }
}
