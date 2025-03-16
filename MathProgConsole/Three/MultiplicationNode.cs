using MathProg.MathOperations;

namespace MathProgConsole.Three;

public class MultiplicationNode : ExpressionNode
{
    private ExpressionNode _left;
    private ExpressionNode _right;

    public MultiplicationNode(ExpressionNode left, ExpressionNode right)
    {
        _left = left;
        _right = right;
    }

    public override double Evaluate(double x) => ArithmeticOperations.Multiply(_left.Evaluate(x), _right.Evaluate(x));

    public override ExpressionNode Derivative() =>
        new AdditionNode(
            new MultiplicationNode(_left.Derivative(), _right),
            new MultiplicationNode(_left, _right.Derivative())
        );

    public override string ToString() => $"({_left} * {_right})";
}