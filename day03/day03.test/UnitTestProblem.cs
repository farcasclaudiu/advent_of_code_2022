namespace day03.test;
using FluentAssertions;
public class UnitTestProblem
{
    [Fact]
    public void TestProblem1()
    {
        var problem = new Problem();
        problem.ResolvePart1("testdata.txt");

        problem.Result1.Should().Be("157");
    }

    [Fact]
    public void TestProblem2()
    {
        var problem = new Problem();
        problem.ResolvePart2("testdata.txt");

        problem.Result2.Should().Be("70");
    }
}