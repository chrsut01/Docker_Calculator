using Docker_Calculator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Docker_Calculator;
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

}