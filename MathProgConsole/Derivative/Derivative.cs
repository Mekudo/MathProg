using static MathProgConsole.Derivative.Parser;
namespace MathProgConsole.Derivative;

public class Derivative
{
     public static double ComputeDerivative(string function, double x0, double delta)
    {
        double fx0PlusDelta = EvaluateExpression(function, x0 + delta);
        double fx0 = EvaluateExpression(function, x0);
        return (fx0PlusDelta - fx0) / delta;
    }

    public static double EvaluateExpression(string expr, double x)
    {
        expr = expr.Replace(" ", ""); // Удаляем пробелы
        var tokens = Tokenize(expr);
        var rpn = ConvertToRPN(tokens); // Обратная польская запись
        return EvaluateRPN(rpn, x);
    }
}