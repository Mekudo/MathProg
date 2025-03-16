using MathProgConsole.Three;

public static class Parser
{
    public static ExpressionNode Parse(string input)
    {
        var tokens = Tokenize(input);
        var iterator = tokens.GetEnumerator();
        iterator.MoveNext();
        return ParseExpression(iterator);
    }

    private static List<string> Tokenize(string input)
    {
        var tokens = new List<string>();
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsWhiteSpace(input[i])) continue;

            if (char.IsLetter(input[i]))
            {
                string function = "";
                while (i < input.Length && char.IsLetter(input[i]))
                {
                    function += input[i];
                    i++;
                }
                tokens.Add(function);
                i--;
            }
            else if (char.IsDigit(input[i]) || input[i] == ',')
            {
                string number = "";
                while (i < input.Length && (char.IsDigit(input[i]) || input[i] == ','))
                {
                    number += input[i];
                    i++;
                }
                tokens.Add(number);
                i--;
            }
            else
            {
                tokens.Add(input[i].ToString());
            }
        }
        return tokens;
    }

    private static ExpressionNode ParseExpression(IEnumerator<string> iterator)
    {
        var left = ParseTerm(iterator);
        while (iterator.Current == "+" || iterator.Current == "-")
        {
            string op = iterator.Current;
            iterator.MoveNext();
            var right = ParseTerm(iterator);
            left = op == "+" ? new AdditionNode(left, right) : new SubtractionNode(left, right);
        }
        return left;
    }

    private static ExpressionNode ParseTerm(IEnumerator<string> iterator)
    {
        var left = ParseFactor(iterator);
        while (iterator.Current == "*" || iterator.Current == "/")
        {
            string op = iterator.Current;
            iterator.MoveNext();
            var right = ParseFactor(iterator);
            left = op == "*" ? new MultiplicationNode(left, right) : new DivisionNode(left, right);
        }
        return left;
    }

    private static ExpressionNode ParseFactor(IEnumerator<string> iterator)
    {
        ExpressionNode node;

        if (iterator.Current == "(")
        {
            iterator.MoveNext();
            node = ParseExpression(iterator);
            if (iterator.Current != ")") throw new Exception("Ожидалась закрывающая скобка");
            iterator.MoveNext();
        }
        else if (iterator.Current == "-")
        {
            iterator.MoveNext();
            node = new MultiplicationNode(new ConstantNode(-1), ParseFactor(iterator));
        }
        else if (char.IsDigit(iterator.Current[0]) || iterator.Current == ".")
        {
            double value = double.Parse(iterator.Current);
            iterator.MoveNext();
            node = new ConstantNode(value);
        }
        else if (iterator.Current == "x")
        {
            iterator.MoveNext();
            node = new VariableNode();
        }
        else if (char.IsLetter(iterator.Current[0]))
        {
            string function = iterator.Current;
            iterator.MoveNext();
            if (iterator.Current != "(") throw new Exception("Ожидалась открывающая скобка после функции");
            iterator.MoveNext();
            var argument = ParseExpression(iterator);
            if (iterator.Current != ")") throw new Exception("Ожидалась закрывающая скобка после аргумента функции");
            iterator.MoveNext();

            switch (function)
            {
                case "sin": node = new SinNode(argument); break;
                case "cos": node = new CosNode(argument); break;
                case "ln": node = new LnNode(argument); break;
                default: throw new Exception($"Неизвестная функция: {function}");
            }
        }
        else
        {
            throw new Exception($"Неожиданный токен: {iterator.Current}");
        }

        if (iterator.Current == "^")
        {
            iterator.MoveNext();
            var exponent = ParseFactor(iterator);
            node = new PowerNode(node, exponent);
        }

        return node;
    }
}