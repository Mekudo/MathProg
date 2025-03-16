string expression = "1/x";
var node = Parser.Parse(expression);

Console.WriteLine($"Исходное уравнение: {node}");
Console.WriteLine($"Производная: {node.Derivative()}");

double x = 2.0;
Console.WriteLine($"Значение уравнения в точке x = {x}: {node.Evaluate(x)}");
Console.WriteLine($"Значения производной в точке x = {x}: {node.Derivative().Evaluate(x)}");