using MathProg.MathOperations;

namespace MathProgConsole.Three;

public class SinNode : ExpressionNode
{
    private ExpressionNode _argument;

    public SinNode(ExpressionNode argument) => _argument = argument;

    public override double Evaluate(double x) => BasicFunctions.Sin(_argument.Evaluate(x));

    public override ExpressionNode Derivative() =>
        new MultiplicationNode(
            new CosNode(_argument),
            _argument.Derivative()
        );

    public override string ToString() => $"sin({_argument})";
}