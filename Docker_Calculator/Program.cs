using Docker_Calculator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Build configuration
        var configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddUserSecrets<Program>();

        var configuration = configBuilder.Build();

        // Configure DbContextOptionsBuilder
        var optionsBuilder = new DbContextOptionsBuilder<CalculatorDbContext>()
            .UseSqlServer(configuration.GetConnectionString("CalculatorDbContext"));

        // Create and use DbContext
        using var dbContext = new CalculatorDbContext(optionsBuilder.Options);
        var calculator = new Calculator(dbContext);
      //  using var dbContext = new CalculatorDbContext();
      //  var calculator = new Calculator(dbContext);

        // Example usage
        var result = calculator.Subtract(41, 5);
        Console.WriteLine($"Subtract Result: {result}");

        var result2 = calculator.Divide(41, 5);
        Console.WriteLine($"Divide Result: {result2}");
    }
}