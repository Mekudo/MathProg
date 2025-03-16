using MathProg.MathOperations;

namespace MathProgConsole.Three;

public class PowerNode : ExpressionNode
{
    private ExpressionNode _base;
    private ExpressionNode _exponent;

    public PowerNode(ExpressionNode baseNode, ExpressionNode exponent)
    {
        _base = baseNode;
        _exponent = exponent;
    }

    public override double Evaluate(double x) => BasicFunctions.Pow(_base.Evaluate(x), _exponent.Evaluate(x));

    public override ExpressionNode Derivative() =>
        new MultiplicationNode(
            new PowerNode(_base, _exponent),
            new AdditionNode(
                new MultiplicationNode(_exponent.Derivative(), new LnNode(_base)),
                new MultiplicationNode(_exponent, new DivisionNode(_base.Derivative(), _base))
            )
        );

    public override string ToString() => $"({_base}^{_exponent})";
}