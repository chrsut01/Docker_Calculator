using Docker_Calculator;
using Moq;

namespace Tests;

[TestFixture]
public class CalculatorTests
{
    private Calculator _calculator;
    private Mock<CalculatorDbContext> _dbContextMock;

    [SetUp]
    public void Setup()
    {
        _dbContextMock = new Mock<CalculatorDbContext>();
        _calculator = new Calculator(_dbContextMock.Object);
    }

    [Test]
    public void Add_TwoNumbers_ReturnsSum()
    {
        // Arrange
        _dbContextMock.Setup(db => db.DataLogs.Add(It.IsAny<DataLog>()));
        _dbContextMock.Setup(db => db.SaveChanges());

        // Act
        double result = _calculator.Add(3, 5);

        // Assert
        Assert.That(result, Is.EqualTo(8));
        _dbContextMock.Verify(db => db.DataLogs.Add(It.IsAny<DataLog>()), Times.Once);
        _dbContextMock.Verify(db => db.SaveChanges(), Times.Once);
    }

    [Test]
    public void Subtract_TwoNumbers_ReturnsDifference()
    {
        // Arrange
        _dbContextMock.Setup(db => db.DataLogs.Add(It.IsAny<DataLog>()));
        _dbContextMock.Setup(db => db.SaveChanges());

        // Act
        double result = _calculator.Subtract(8, 3);

        // Assert
        Assert.That(result, Is.EqualTo(5));
        _dbContextMock.Verify(db => db.DataLogs.Add(It.IsAny<DataLog>()), Times.Once);
        _dbContextMock.Verify(db => db.SaveChanges(), Times.Once);
    }

    [Test]
    public void Multiply_TwoNumbers_ReturnsProduct()
    {
        // Arrange
        _dbContextMock.Setup(db => db.DataLogs.Add(It.IsAny<DataLog>()));
        _dbContextMock.Setup(db => db.SaveChanges());

        // Act
        double result = _calculator.Multiply(4, 6);

        // Assert
        Assert.That(result, Is.EqualTo(24));
        _dbContextMock.Verify(db => db.DataLogs.Add(It.IsAny<DataLog>()), Times.Once);
        _dbContextMock.Verify(db => db.SaveChanges(), Times.Once);
    }

    [Test]
    public void Divide_ValidNumbers_ReturnsQuotient()
    {
        // Arrange
        _dbContextMock.Setup(db => db.DataLogs.Add(It.IsAny<DataLog>()));
        _dbContextMock.Setup(db => db.SaveChanges());

        // Act
        double result = _calculator.Divide(10, 2);

        // Assert
        Assert.That(result, Is.EqualTo(5));
        _dbContextMock.Verify(db => db.DataLogs.Add(It.IsAny<DataLog>()), Times.Once);
        _dbContextMock.Verify(db => db.SaveChanges(), Times.Once);
    }

    [Test]
    public void Divide_DivideByZero_ThrowsException()
    {
        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));

        // Verify that database interactions did not occur in this case
        _dbContextMock.Verify(db => db.DataLogs.Add(It.IsAny<DataLog>()), Times.Never);
        _dbContextMock.Verify(db => db.SaveChanges(), Times.Never);
    }
}