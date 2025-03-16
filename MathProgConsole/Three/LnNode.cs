namespace MathProgConsole.Three;

public class LnNode : ExpressionNode
{
    private ExpressionNode _argument;

    public LnNode(ExpressionNode argument) => _argument = argument;

    public override double Evaluate(double x) => Math.Log(_argument.Evaluate(x));

    public override ExpressionNode Derivative() =>
        new DivisionNode(
            _argument.Derivative(),
            _argument
        );

    public override string ToString() => $"ln({_argument})";
}