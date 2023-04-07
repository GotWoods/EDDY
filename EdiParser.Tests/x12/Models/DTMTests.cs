using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class DTMTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "DTM*mNK*mUTsFFFy*JZp1*WT*7C*q";

        var expected = new DTM_DateTimeReference()
        {
            DateTimeQualifier = "mNK",
            Date = "mUTsFFFy",
            Time = "JZp1",
            TimeCode = "WT",
            DateTimePeriodFormatQualifier = "7C",
            DateTimePeriod = "q",
        };

        var actual = Map.MapObject<DTM_DateTimeReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("mNK", true)]
    public void Validatation_RequiredDateTimeQualifier(string dateTimeQualifier, bool isValidExpected)
    {
        var subject = new DTM_DateTimeReference();
        subject.DateTimeQualifier = dateTimeQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "1234", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
    {
        var subject = new DTM_DateTimeReference();
        subject.DateTimeQualifier = "mNK";
        subject.TimeCode = timeCode;
        subject.Time = time;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
    {
        var subject = new DTM_DateTimeReference();
        subject.DateTimeQualifier = "mNK";
        subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
        subject.DateTimePeriod = dateTimePeriod;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}