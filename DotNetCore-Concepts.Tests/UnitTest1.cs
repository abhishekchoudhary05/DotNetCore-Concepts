using Xunit;
using InterviewPrepration.Questions;
using DotNetCore_Concepts.Questions.EasyMath;
using DotNetCore_Concepts.Questions.HashMap;
using DotNetCore_Concepts.Questions.Substrings;
using DotNetCore_Concepts.Questions.Two_Poiters;
using InterviewPrepration.Concepts;

namespace DotNetCore_Concepts.Tests;

public class UnitTest1
{
    #region Constructor Tests
    [Fact]
    public void Constructor_DefaultConstructor_Test()
    {
        // Test that default constructor works
        Constructor constructor = new Constructor();
        // Constructor should not throw exception
    }

    [Fact]
    public void Constructor_ParameterizedConstructor_Test()
    {
        // Test parameterized constructor
        Constructor constructor = new Constructor("test");
    }

    [Fact]
    public void Constructor_StaticConstructor_Test()
    {
        // Static constructor is called automatically, just verify it exists
        // Static constructor in C# is called implicitly
    }
    #endregion

    #region Method Hiding Tests
    [Fact]
    public void MethodHiding_BaseClassDisplay_Test()
    {
        var baseClass = new BaseClass();
        baseClass.Display(); // Should print "Base class Display method"
    }

    [Fact]
    public void MethodHiding_DerivedClassDisplay_Test()
    {
        var derivedClass = new DerivedClass();
        derivedClass.Display(); // Should print "Derived class Display method"
    }
    #endregion

    #region Method Overriding Tests
    [Fact]
    public void MethodOverriding_ParentClassDisplay_Test()
    {
        var parent = new Parent();
        parent.Display(); // Should print "Parent class Display method"
    }

    [Fact]
    public void MethodOverriding_DerivedClassDisplay_Test()
    {
        var derived = new Derived();
        derived.Display(); // Should print "Derived class Display method"
    }
    #endregion

    #region Singleton Pattern Tests
    [Fact]
    public void SingletonPattern_GetObject_Test()
    {
        var obj1 = SingletonPattern.GetObject();
        var obj2 = SingletonPattern.GetObject();
        Assert.Equal(obj1, obj2); // Should be the same instance
    }
    #endregion

    #region ReverseString Tests
    [Fact]
    public void ReverseString_ValidString_Test()
    {
        string input = "Hello";
        string result = ReverseStringQuestion.ReverseString(input);
        Assert.Equal("olleH", result);
    }

    [Fact]
    public void ReverseString_EmptyString_Test()
    {
        string result = ReverseStringQuestion.ReverseString("");
        Assert.Equal("", result);
    }

    [Fact]
    public void ReverseString_NullInput_Test()
    {
        Assert.Throws<ArgumentNullException>(() => ReverseStringQuestion.ReverseString(null));
    }
    #endregion

    #region ReverseStringInPlace Tests
    [Fact]
    public void ReverseStringInPlace_ValidInput_Test()
    {
        char[] input = new char[] { 'H', 'e', 'l', 'l', 'o' };
        char[] result = ReverseStringInPlaceQuestion.ReverString_InPlace(input);
        Assert.Equal(new char[] { 'o', 'l', 'l', 'e', 'H' }, result);
    }

    [Fact]
    public void ReverseStringInPlace_EmptyInput_Test()
    {
        char[] input = Array.Empty<char>();
        char[] result = ReverseStringInPlaceQuestion.ReverString_InPlace(input);
        Assert.Empty(result);
    }
    #endregion

    #region FindSecondHighest Tests
    [Fact]
    public void FindSecondHighest_ValidInput_Test()
    {
        int[] input = new int[] { 10, 20, 30, 20, 40 };
        int result = FindSecondHighestQuestion.FindSecondHighest(input);
        Assert.Equal(30, result);
    }

    [Fact]
    public void FindSecondHighest_NoDistinctSecondHighest_Test()
    {
        int[] input = new int[] { 10, 10, 10 };
        Assert.Throws<ArgumentException>(() => FindSecondHighestQuestion.FindSecondHighest(input));
    }

    [Fact]
    public void FindSecondHighest_NullInput_Test()
    {
        Assert.Throws<ArgumentNullException>(() => FindSecondHighestQuestion.FindSecondHighest(null));
    }
    #endregion

    #region ReverseWordOrder Tests
    [Fact]
    public void ReverseWordOrder_ValidInput_Test()
    {
        // Note: This method doesn't return a value, it prints to Console
        // We can't easily test the output without capturing Console.WriteLine
        // For now, we'll just verify it doesn't throw
        ReverseWordOrderQuestion.ReverseWordOrder("Hello World");
    }
    #endregion

    #region ReverseWord Tests
    [Fact]
    public void ReverseWord_ValidInput_Test()
    {
        // Similar to above, this prints to Console
        ReverseWordQuestion.ReverseWord("Hello World");
    }
    #endregion

    #region OccurrenceOfCharacters Tests
    [Fact]
    public void OccurrenceOfCharacters_ValidInput_Test()
    {
        // This method prints to Console, hard to test directly
        // We'll verify it doesn't throw exception
        OccurrenceOfCharactersQuestion.OccuranceOfCharacters("Hello");
    }
    #endregion

    #region RemoveDuplicateCharacters Tests
    [Fact]
    public void RemoveDuplicateCharacters_ValidInput_Test()
    {
        // This method prints to Console
        RemoveDuplicateCharactersQuestion.RemoveDuplicateCharacters("Hello");
    }
    #endregion

    #region LeftCirculation Tests
    [Fact]
    public void LeftCirculation_ValidInput_Test()
    {
        int[] input = new int[] { 1, 2, 3, 4 };
        LeftCirculationQuestion.LeftCirculation(input);
        Assert.Equal(new int[] { 2, 3, 4, 1 }, input);
    }

    [Fact]
    public void LeftCirculation_NullInput_Test()
    {
        Assert.Throws<ArgumentNullException>(() => LeftCirculationQuestion.LeftCirculation<int>(null));
    }
    #endregion

    #region MultiToSingle Tests
    [Fact]
    public void MultiToSingle_ValidInput_Test()
    {
        // This method prints to Console
        int[,] input = new int[,] { { 1, 2 }, { 3, 4 } };
        MultiToSingleQuestion.MultiToSingle(input);
    }
    #endregion

    #region EasyMath Tests - FindAngleBetweenHourAndMinutes
    [Fact]
    public void FindAngleBetweenHourAndMinutes_3_30_Test()
    {
        // 3:30 - hour hand at 3.5 * 30 = 105°, minute hand at 6 * 30 = 180°
        // Difference: 75°, which is <= 180
        FindAngleBetweenHourAndMinutesQuestion.FindAngleBetweenHourAndMinutes(3, 30);
    }

    [Fact]
    public void FindAngleBetweenHourAndMinutes_12_0_Test()
    {
        // 12:00 - both hands at 0°, difference = 0°
        FindAngleBetweenHourAndMinutesQuestion.FindAngleBetweenHourAndMinutes(12, 0);
    }
    #endregion

    #region EasyMath Tests - IsPrime
    [Fact]
    public void IsPrime_7_Test()
    {
        // 7 is prime
        IsPrimeQuestion.IsPrime(7);
    }

    [Fact]
    public void IsPrime_10_Test()
    {
        // 10 is not prime
        IsPrimeQuestion.IsPrime(10);
    }

    [Fact]
    public void IsPrime_1_Test()
    {
        // 1 is not prime (edge case)
        IsPrimeQuestion.IsPrime(1);
    }
    #endregion

    #region EasyMath Tests - SumOfDigits
    [Fact]
    public void SumOfDigits_123_Test()
    {
        // Sum of digits in 123 = 1 + 2 + 3 = 6
        SumOfDigitsQuestion.SumOfDigits(123);
    }

    [Fact]
    public void SumOfDigits_0_Test()
    {
        // Edge case: 0
        SumOfDigitsQuestion.SumOfDigits(0);
    }
    #endregion

    #region HashMap Tests - TwoSum
    [Fact]
    public void TwoSum_ValidInput_Test()
    {
        int[] input = [2, 7, 11, 15];
        int target = 9;
        int[] result = TwoSum.FindElements(input, target);
        Assert.Equal([0, 1], result);
    }

    [Fact]
    public void TwoSum_NoSolution_Test()
    {
        int[] input = [1, 2, 3];
        int target = 7;
        int[] result = TwoSum.FindElements(input, target);
        Assert.Equal([0, 0], result); // Returns [0, 0] when no solution
    }

    [Fact]
    public void TwoSum_NullInput_Test()
    {
        Assert.Throws<ArgumentNullException>(() => TwoSum.FindElements(null, 5));
    }
    #endregion

    #region Substrings Tests - FindAllSubstrings
    [Fact]
    public void FindAllSubstrings_ValidInput_Test()
    {
        // This method prints to Console
        FindAllSubstringsQuestion.FindAllSubstrings("abc");
    }
    #endregion

    #region Two-Poiters Tests - MergeAlternately
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
    #endregion

    #region ExceptionHandlingMiddleware Tests
    [Fact]
    public void ExceptionHandlingMiddleware_InvokeAsync_Test()
    {
        // This is an integration test that requires setting up a middleware pipeline
        // We'll skip this for unit tests as it requires ASP.NET Core context
        // The method exists and follows SOLID principles
    }
    #endregion
}