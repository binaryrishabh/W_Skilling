using Xunit;

namespace CalculatorLib.Tests;

public class CalculatorTests {
    private readonly Calculator _calc = new();

    [Fact]
    public void Add_TwoPositiveNumbers_ReturnsSum() {
        double result = _calc.Add(5, 3);
        Assert.Equal(8, result);
    }

    [Fact]
    public void Add_WithZero_ReturnsSameNumber() {
        Assert.Equal(5, _calc.Add(5, 0));
        Assert.Equal(7, _calc.Add(0, 7));
    }

    [Fact]
    public void Subtract_PositiveNumbers_ReturnsDifference() {
        Assert.Equal(2, _calc.Subtract(5, 3));
    }

    [Fact]
    public void Multiply_TwoNumbers_ReturnsProduct() {
        Assert.Equal(15, _calc.Multiply(5, 3));
    }

    [Fact]
    public void Divide_ValidNumbers_ReturnsQuotient() {
        Assert.Equal(2, _calc.Divide(6, 3));
    }

    [Fact]
    public void Divide_ByZero_ThrowsException() {
        Assert.Throws<DivideByZeroException>(() => _calc.Divide(5, 0));
    }
}