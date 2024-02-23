using Docker_Calculator;

class Program
{
    static void Main()
    {
        using var dbContext = new CalculatorDbContext();
        var calculator = new Calculator(dbContext);

        // Example usage
        var result = calculator.Subtract(21, 3);
        Console.WriteLine($"Subtract Result: {result}");

        var result2 = calculator.Divide(21, 3);
        Console.WriteLine($"Divide Result: {result2}");
    }
}