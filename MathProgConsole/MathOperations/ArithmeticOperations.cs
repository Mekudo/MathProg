namespace MathProg.MathOperations;

public static class ArithmeticOperations
{
    public static double Sum(double a, double b)
    {
        return a + b;
    }
    
    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    public static double Multiply(double a, double b)
    {
        return a * b;
    }
    
    public static double Divide(double a, double b)
    {
        if (b == 0)
            throw new DivideByZeroException("Деление на ноль невозможно.");
        return a / b;
    }
}