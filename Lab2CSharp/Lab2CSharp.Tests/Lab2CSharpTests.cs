using Xunit;

namespace Lab2CSharp.Tests;

public class ProgramTests
{
    [Fact]
    public void Task1_ShouldReturnCorrectOddIndices()
    {
        // Симулюємо ввід: Розмір 5, Елементи: 10, 11, 12, 13, 14
        var input = string.Join(Environment.NewLine, new[] { "5", "10", "11", "12", "13", "14" });
        using var reader = new StringReader(input);
        Console.SetIn(reader);

        var result = Program.Task1();

        Assert.Equal(new int[] { 1, 3 }, result);
    }

    [Fact]
    public void Task2_ShouldReturnMaxNegativeValue()
    {
        // 2 рядки, 2 стовпці: -10, 5, -2, 0
        var input = string.Join(Environment.NewLine, new[] { "2", "2", "-10", "5", "-2", "0" });
        using var reader = new StringReader(input);
        Console.SetIn(reader);

        var result = Program.Task2();

        Assert.Equal(-2, result);
    }

    [Fact]
    public void Task3_ShouldReturnSnakePattern()
    {
        /* Матриця 2x2
           1 2
           3 4
           Очікуємо "Змійку": 1, 2 (вправо), потім 4, 3 (вліво)
        */
        var input = string.Join(Environment.NewLine, new[] { "2", "1", "2", "3", "4" });
        using var reader = new StringReader(input);
        Console.SetIn(reader);

        var result = Program.Task3();

        Assert.Equal(new int[] { 1, 2, 4, 3 }, result.Item1);
    }

    [Fact]
    public void Task4_ShouldCalculateRowSumsAndMaxSum()
    {
        /* 
           Рядок 1: 2 елементи (1, 2) -> сума 3
           Рядок 2: 3 елементи (10, 20, 30) -> сума 60
        */
        var input = string.Join(Environment.NewLine, new[] { "2", "2", "1", "2", "3", "10", "20", "30" });
        using var reader = new StringReader(input);
        Console.SetIn(reader);

        var (sums, maxSum) = Program.Task4();

        Assert.Equal(new int[] { 3, 60 }, sums);
        Assert.Equal(60, maxSum);
    }

    [Fact]
    public void Task2_NoNegatives_ShouldThrowException()
    {
        // Всі числа додатні
        var input = string.Join(Environment.NewLine, new[] { "1", "1", "10" });
        using var reader = new StringReader(input);
        Console.SetIn(reader);

        Assert.Throws<InvalidOperationException>(() => Program.Task2());
    }
}