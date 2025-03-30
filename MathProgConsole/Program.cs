using MathProgConsole.Derivative;

Console.WriteLine("Введите функцию f(x), например: sin(x)^2 + 3*x^3");
string function = Console.ReadLine();

Console.WriteLine("Введите точку x0, в которой нужно найти производную:");
double x0 = double.Parse(Console.ReadLine());

Console.WriteLine("Введите величину delta (малое число, например 0.0001):");
double delta = double.Parse(Console.ReadLine());

try
{
    double derivative = Derivative.ComputeDerivative(function, x0, delta);
    Console.WriteLine($"Приближённое значение производной в точке {x0} = {derivative}");
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}

   