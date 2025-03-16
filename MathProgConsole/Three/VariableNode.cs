namespace MathProgConsole.Three;

public class VariableNode : ExpressionNode
{
    public override double Evaluate(double x) => x;

    public override ExpressionNode Derivative() => new ConstantNode(1);

    public override string ToString() => "x";
}