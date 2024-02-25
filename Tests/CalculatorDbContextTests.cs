using System;
using System.IO;
using Docker_Calculator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

[TestFixture]
public class CalculatorDbContextTests
{
    [Test]
    public void CanAddAndRetrieveDataLog()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<CalculatorDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        using (var context = new CalculatorDbContext(options))
        {
            var dataLog = new DataLog { n1 = 1, n2 = 2, Operator = "Add", Result = 3 };

            // Act
            context.DataLogs.Add(dataLog);
            context.SaveChanges();
        }

        // Assert
        using (var context = new CalculatorDbContext(options))
        {
            var retrievedDataLog = context.DataLogs.FirstOrDefault();

            Assert.NotNull(retrievedDataLog);
            Assert.AreEqual(1, retrievedDataLog.n1);
            Assert.AreEqual(2, retrievedDataLog.n2);
            Assert.AreEqual("Add", retrievedDataLog.Operator);
            Assert.AreEqual(3, retrievedDataLog.Result);
        }
    }
}