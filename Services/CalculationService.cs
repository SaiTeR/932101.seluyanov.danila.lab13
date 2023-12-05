using Lab11.Models;

public interface ICalculationService
{
    int Add(int a, int b);
    int Subtract(int a, int b);
    int Multiply(int a, int b);
    double Divide(int a, int b);


    double Calculate(int a, int b, string opeartion);
}

public class CalculationService : ICalculationService
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public int Subtract(int a, int b)
    {
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }

    public double Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Деление на 0!!!");
        }
        return (double)a / b;
    }

    public double Calculate(int a, int b, string operation)
    {
        double result;

        switch(operation)
        {
            case "+":
                result = Add(a, b);
                break;

            case "-":
                result = Subtract(a, b);
                break;

            case "*":
                result = Multiply(a, b);
                break;

            case "/":
                result = Divide(a, b);
                break;

            default:
                throw new Exception("SOMETHING WENT WRONG!");
        }

        return result;
    }
}



