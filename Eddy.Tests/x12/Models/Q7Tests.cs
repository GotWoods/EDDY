using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class Q7Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "Q7*a*hFn*7";

        var expected = new Q7_LadingExceptionStatus()
        {
            LadingExceptionCode = "a",
            PackagingFormCode = "hFn",
            LadingQuantity = 7,
        };

        var actual = Map.MapObject<Q7_LadingExceptionStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithTilde);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("a", true)]
    public void Validatation_RequiredLadingExceptionCode(string ladingExceptionCode, bool isValidExpected)
    {
        var subject = new Q7_LadingExceptionStatus();
        subject.LadingExceptionCode = ladingExceptionCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("", 1, true)]
    [InlineData("v11", 0, false)]
    public void Validation_ARequiresBPackagingFormCode(string packagingFormCode, int ladingQuantity, bool isValidExpected)
    {
        var subject = new Q7_LadingExceptionStatus();
        subject.LadingExceptionCode = "a";
        subject.PackagingFormCode = packagingFormCode;
        if (ladingQuantity > 0)
            subject.LadingQuantity = ladingQuantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}