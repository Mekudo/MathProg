using MathProg.MathOperations;

namespace MathProgConsole.Three;

public class AdditionNode : ExpressionNode
{
    private ExpressionNode _left;
    private ExpressionNode _right;

    public AdditionNode(ExpressionNode left, ExpressionNode right)
    {
        _left = left;
        _right = right;
    }

    public override double Evaluate(double x) => ArithmeticOperations.Sum(_left.Evaluate(x), _right.Evaluate(x));

    public override ExpressionNode Derivative() => new AdditionNode(_left.Derivative(), _right.Derivative());

    public override string ToString() => $"({_left} + {_right})";
}