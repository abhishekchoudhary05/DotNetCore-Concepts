using Xunit;
using DotNetCore_Concepts.Questions.Two_Poiters;

namespace DotNetCore_Concepts.Tests.Questions.Two_Poiters;

public class MergeAlternatelyTests
{
    [Fact]
    public void MergeAlternately_ValidInput_Test()
    {
        string result = MergeAlternately.Merge("abc", "def");
        Assert.Equal("adbecf", result);
    }

    [Fact]
    public void MergeAlternately_OneEmptyString_Test()
    {
        string result = MergeAlternately.Merge("abc", "");
        Assert.Equal("abc", result);
    }
}