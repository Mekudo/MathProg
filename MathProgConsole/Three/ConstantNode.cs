namespace MathProgConsole.Three;

public class ConstantNode : ExpressionNode
{
    private double _value;

    public ConstantNode(double value) => _value = value;
    
    public override double Evaluate(double x) => _value;

    public override ExpressionNode Derivative() => new ConstantNode(0);

    public override string ToString() => _value.ToString();
}