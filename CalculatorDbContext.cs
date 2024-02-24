using Docker_Calculator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
public class CalculatorDbContext : DbContext
{
    public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options)
        : base(options)
    {
    }
    
    public CalculatorDbContext()
    {
       
    }

    public virtual DbSet<DataLog> DataLogs { get; set; }
/*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
        var configBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        var configuration = configBuilder.Build();

        string connectionString = configuration.GetConnectionString("CalculatorDbContext") ?? throw new InvalidOperationException();
       
        
            optionsBuilder.UseSqlServer(connectionString);
        }
    }*/
}