using MathProg.MathOperations;

namespace MathProgConsole.Three;

public class DivisionNode : ExpressionNode
{
    private ExpressionNode _numerator;
    private ExpressionNode _denominator;

    public DivisionNode(ExpressionNode numerator, ExpressionNode denominator)
    {
        _numerator = numerator;
        _denominator = denominator;
    }

    public override double Evaluate(double x) =>
        ArithmeticOperations.Divide(_numerator.Evaluate(x), _denominator.Evaluate(x));

    public override ExpressionNode Derivative() =>
        new DivisionNode(
            new SubtractionNode(
                new MultiplicationNode(_numerator.Derivative(), _denominator),
                new MultiplicationNode(_numerator, _denominator.Derivative())
            ),
            new PowerNode(_denominator, new ConstantNode(2))
        );

    public override string ToString() => $"({_numerator} / {_denominator})";
}