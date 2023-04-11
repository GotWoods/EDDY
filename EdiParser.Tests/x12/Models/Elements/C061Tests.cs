using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models.Elements;

public class C061Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "D*o*A6J*GBTPTnfQ*ee7jJ1Lo";

        var expected = new C061_MemberHealthAndTreatmentInformation()
        {
            HealthRelatedCode = "D",
            YesNoConditionOrResponseCode = "o",
            DateTimeQualifier = "A6J",
            Date = "GBTPTnfQ",
            Date2 = "ee7jJ1Lo",
        };

        var actual = Map.MapObject<C061_MemberHealthAndTreatmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", "",  "",true)]
    [InlineData("A6J", "", "", false)]
    [InlineData("A6J", "GBTPTnfQ", "",true)]
    [InlineData("A6J", "", "asdfasdf",true)]
    public void Validation_NEWDateTimeQualifier(string dateTimeQualifier, string date, string date2, bool isValidExpected)
    {
        var subject = new C061_MemberHealthAndTreatmentInformation();
        subject.DateTimeQualifier = dateTimeQualifier;
        subject.Date = date;
        subject.Date2 = date2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("GBTPTnfQ", "A6J", true)]
    [InlineData("GBTPTnfQ", "", false)]
    public void Validation_ARequiresBDate(string date, string dateTimeQualifier, bool isValidExpected)
    {
        var subject = new C061_MemberHealthAndTreatmentInformation();
        subject.Date = date;
        subject.DateTimeQualifier = dateTimeQualifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("ee7jJ1Lo", "A6J", true)]
    [InlineData("ee7jJ1Lo", "", false)]
    public void Validation_ARequiresBDate2(string date2, string dateTimeQualifier, bool isValidExpected)
    {
        var subject = new C061_MemberHealthAndTreatmentInformation();
        subject.Date2 = date2;
        subject.DateTimeQualifier = dateTimeQualifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

}