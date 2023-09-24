using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PODTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "POD*wyWivH9T*45Dj*a";

        var expected = new POD_ProofOfDelivery()
        {
            Date = "wyWivH9T",
            Time = "45Dj",
            Name = "a",
        };

        var actual = Map.MapObject<POD_ProofOfDelivery>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("12345678", true)]
    public void Validation_RequiredDate(string date, bool isValidExpected)
    {
        var subject = new POD_ProofOfDelivery();
        subject.Name = "AB";
        subject.Date = date;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("v1", true)]
    public void Validation_RequiredName(string name, bool isValidExpected)
    {
        var subject = new POD_ProofOfDelivery();
        subject.Date = "12345678";
        subject.Name = name;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}