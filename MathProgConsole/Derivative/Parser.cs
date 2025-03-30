namespace MathProgConsole.Derivative;

public class Parser
{
     // Разбиваем выражение на токены (числа, операторы, функции, скобки)
     public static List<string> Tokenize(string expr)
    {
        var tokens = new List<string>();
        int i = 0;
        while (i < expr.Length)
        {
            if (char.IsDigit(expr[i]) || expr[i] == '.')
            {
                string num = "";
                while (i < expr.Length && (char.IsDigit(expr[i]) || expr[i] == '.'))
                    num += expr[i++];
                tokens.Add(num);
            }
            else if (char.IsLetter(expr[i]))
            {
                string func = "";
                while (i < expr.Length && char.IsLetter(expr[i]))
                    func += expr[i++];
                tokens.Add(func);
            }
            else
            {
                tokens.Add(expr[i++].ToString());
            }
        }
        return tokens;
    }

    // Конвертируем в обратную польскую запись (алгоритм сортировочной станции)
    public static List<string> ConvertToRPN(List<string> tokens)
    {
        var output = new List<string>();
        var operators = new Stack<string>();

        var precedence = new Dictionary<string, int>
        {
            { "^", 4 },
            { "*", 3 }, { "/", 3 },
            { "+", 2 }, { "-", 2 }
        };

        foreach (var token in tokens)
        {
            if (double.TryParse(token, out _) || token == "x")
            {
                output.Add(token);
            }
            else if (token == "(")
            {
                operators.Push(token);
            }
            else if (token == ")")
            {
                while (operators.Count > 0 && operators.Peek() != "(")
                    output.Add(operators.Pop());
                operators.Pop(); // Удаляем "("
            }
            else if (precedence.ContainsKey(token))
            {
                while (operators.Count > 0 && precedence.ContainsKey(operators.Peek()) &&
                       precedence[operators.Peek()] >= precedence[token])
                {
                    output.Add(operators.Pop());
                }
                operators.Push(token);
            }
            else // Функция (sin, cos и т. д.)
            {
                operators.Push(token);
            }
        }

        while (operators.Count > 0)
            output.Add(operators.Pop());

        return output;
    }

    public static double EvaluateRPN(List<string> rpn, double x)
    {
        var stack = new Stack<double>();

        foreach (var token in rpn)
        {
            if (double.TryParse(token, out double num))
            {
                stack.Push(num);
            }
            else if (token == "x")
            {
                stack.Push(x);
            }
            else if (token == "+")
            {
                stack.Push(stack.Pop() + stack.Pop());
            }
            else if (token == "-")
            {
                double b = stack.Pop();
                double a = stack.Pop();
                stack.Push(a - b);
            }
            else if (token == "*")
            {
                stack.Push(stack.Pop() * stack.Pop());
            }
            else if (token == "/")
            {
                double b = stack.Pop();
                double a = stack.Pop();
                stack.Push(a / b);
            }
            else if (token == "^")
            {
                double b = stack.Pop();
                double a = stack.Pop();
                stack.Push(Math.Pow(a, b));
            }
            else if (token == "sin")
            {
                stack.Push(Math.Sin(stack.Pop()));
            }
            else if (token == "cos")
            {
                stack.Push(Math.Cos(stack.Pop()));
            }
            else if (token == "tan")
            {
                stack.Push(Math.Tan(stack.Pop()));
            }
            else if (token == "exp")
            {
                stack.Push(Math.Exp(stack.Pop()));
            }
            else if (token == "log")
            {
                stack.Push(Math.Log(stack.Pop()));
            }
        }

        return stack.Pop();
    }
}