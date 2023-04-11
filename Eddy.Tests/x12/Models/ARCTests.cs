using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ARCTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ARC*6*sD";

        var expected = new ARC_AnimalResultsCounts
        {
            Count = 6,
            TestTypeCode = "sD",
            //ObservationTypeCode = "ji"
        };

        var actual = Map.MapObject<ARC_AnimalResultsCounts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(6, true)]
    public void Validatation_RequiredCount(int count, bool isValidExpected)
    {
        var subject = new ARC_AnimalResultsCounts();
        subject.TestTypeCode = "AB";
        if (count > 0)
            subject.Count = count;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", "", false)]
    [InlineData("", "ji", true)]
    [InlineData("sD", "", true)]
    public void Validation_AtLeastOneTestTypeCode(string testTypeCode, string observationTypeCode, bool isValidExpected)
    {
        var subject = new ARC_AnimalResultsCounts();
        subject.Count = 6;
        subject.TestTypeCode = testTypeCode;
        subject.ObservationTypeCode = observationTypeCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }

    [Theory]
    [InlineData("sD", "ji", false)]
    [InlineData("", "ji", true)]
    [InlineData("sD", "", true)]
    public void Validation_OnlyOneOfTestTypeCode(string testTypeCode, string observationTypeCode, bool isValidExpected)
    {
        var subject = new ARC_AnimalResultsCounts();
        subject.Count = 6;
        subject.TestTypeCode = testTypeCode;
        subject.ObservationTypeCode = observationTypeCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
    }
}