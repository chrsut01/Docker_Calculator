using Microsoft.EntityFrameworkCore;

namespace Docker_Calculator;

public class Calculator : ICalculator
{
    private readonly CalculatorDbContext _dbContext;

    public Calculator(CalculatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public double Add(double a, double b)
    {
        LogCalculation(a, b, "Add", a + b);
        return a + b;
    }

    public double Subtract(double a, double b)
    {
        LogCalculation(a, b, "Subtract", a - b);
        return a - b;
    }

    public double Multiply(double a, double b)
    {
        LogCalculation(a, b, "Multiply", a * b);
        return a * b;   
    }

    public double Divide(double a, double b)
    {
        if (b != 0){
            LogCalculation(a, b, "Divide", a / b);
            return a / b;
        }
        else{
            throw new DivideByZeroException("Cannot divide by zero.");;
        }
    }

    private void LogCalculation(double number1, double number2, string @operator, double result)
    {
        var log = new DataLog
        {
            n1 = number1,
            n2 = number2,
            Operator = @operator,
            Result = result,
        };
        _dbContext.DataLogs.Add(log);
        _dbContext.SaveChanges();
    }
}