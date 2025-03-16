using MathProg.MathOperations;

namespace MathProgConsole.Three;

public class CosNode : ExpressionNode
{
    private ExpressionNode _argument;

    public CosNode(ExpressionNode argument) => _argument = argument;

    public override double Evaluate(double x) => BasicFunctions.Cos(_argument.Evaluate(x));

    public override ExpressionNode Derivative() =>
        new MultiplicationNode(
            new MultiplicationNode(new ConstantNode(-1), new SinNode(_argument)),
            _argument.Derivative()
        );

    public override string ToString() => $"cos({_argument})";
}