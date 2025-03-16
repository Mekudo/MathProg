namespace MathProg.MathOperations;

public static class BasicFunctions
{
    private const double PI = 3.14159265358979323846;
    private const double twoPI = 2 * PI;

    public static double Abs(double value)
    {
        return value < 0 ? -value : value;
    }

    public static double Factorial(double value)
    {
        if (value < 0)
            throw new ArgumentException("Число для факториала не может быть меньше 0");
        
        double result = 1;

        for (int i = 2; i <= value; i++)
        {
            result *= i;
        }
        
        return result;
    }

    public static double Pow(double x, double n)
    {
        if (n < 0)
            throw new ArgumentException("Пока поддерживаются только целые неотрицательные степени.");

        double result = 1;
        
        for (int i = 0; i < n; i++)
        {
            result *= x;
        }
        
        return result;
    }

    public static double Sin(double value)
    {
        double radian = value * PI / 180;
        
        radian = radian % twoPI;
        
        if (radian < 0)
        {
            radian += twoPI;
        }
        double result = 0;

        double term = radian;

        int n = 1;
        
        while (Abs(term) > 1e-10)
        {
            result += term;
            term = -term * radian * radian / ((2 * n) * (2 * n + 1));
            n++;
        }
            
        return result;
    }
    
    public static double Cos(double value)
    {
        double radian = value * PI / 180;
        
        radian = radian % twoPI;
        
        if (radian < 0)
        {
            radian += twoPI;
        }
        double result = 0;

        double term = 1;

        int n = 1;
        
        while (Abs(term) > 1e-10)
        {
            result += term;
            term = -term * radian * radian / ((2 * n - 1) * (2 * n));
            n++;
        }
            
        return result;
    }
    
    public static double Exp(double x)
    {
        double result = 0;
        double term = 1;
        int n = 0;

        while (Abs(term) > 1e-10)
        {
            result += term;
            n++;
            term = term * x / n;
        }

        return result;
    }
}