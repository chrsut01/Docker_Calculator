using Microsoft.EntityFrameworkCore;

namespace Docker_Calculator;

public class Calculator : ICalculator
{
    private readonly CalculatorDbContext _dbContext;

    public Calculator(CalculatorDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public double Add(double n1, double n2)
    {
        LogCalculation(n1, n2, "Add", n1 + n2);
        return n1 + n2;
    }

    public double Subtract(double n1, double n2)
    {
        LogCalculation(n1, n2, "Subtract", n1 - n2);
        return n1 - n2;
    }

    public double Multiply(double n1, double n2)
    {
        LogCalculation(n1, n2, "Multiply", n1 * n2);
        return n1 * n2;   
    }

    public double Divide(double n1, double n2)
    {
        if (n2 != 0){
            LogCalculation(n1, n2, "Divide", n1 / n2);
            return n1 / n2;
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