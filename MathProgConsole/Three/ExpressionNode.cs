namespace MathProgConsole.Three;

public abstract class ExpressionNode
{
    public abstract double Evaluate(double x);
    public abstract ExpressionNode Derivative();
    public abstract override string ToString();
}