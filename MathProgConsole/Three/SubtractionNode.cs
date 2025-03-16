using MathProg.MathOperations;

namespace MathProgConsole.Three;

public class SubtractionNode : ExpressionNode
{
    private ExpressionNode _left;
    private ExpressionNode _right;

    public SubtractionNode(ExpressionNode left, ExpressionNode right)
    {
        _left = left;
        _right = right;
    }

    public override double Evaluate(double x) => ArithmeticOperations.Subtract(_left.Evaluate(x), _right.Evaluate(x));

    public override ExpressionNode Derivative() => new SubtractionNode(_left.Derivative(), _right.Derivative());

    public override string ToString() => $"({_left} - {_right})";
}