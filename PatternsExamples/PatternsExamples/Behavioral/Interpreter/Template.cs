namespace PatternsExamples.Behavioral.Interpreter
{
    class Client
    {
        void Main()
        {
            Context context = new Context();

            NonterminalExpression expression = new NonterminalExpression();
            expression.Interpret(context);

        }
    }

    class Context
    {
    }

    abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
        }
    }

    class NonterminalExpression : AbstractExpression
    {
        AbstractExpression _expression1;
        AbstractExpression _expression2;

        public override void Interpret(Context context)
        {

        }
    }
}
