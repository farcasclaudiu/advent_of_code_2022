namespace day04.test;
using FluentAssertions;
public class UnitTestProblem
{
    [Fact]
    public void TestProblem1()
    {
        var problem = new Problem();
        problem.ResolvePart1("testdata.txt");

        problem.Result1.Should().Be("2");
    }

    [Fact]
    public void TestProblem2()
    {
        var problem = new Problem();
        problem.ResolvePart2("testdata.txt");

        problem.Result2.Should().Be("4");
    }
}